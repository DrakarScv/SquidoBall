using UnityEngine;

public class BallControler : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private Vector3 _startBallPos = Vector3.zero;
    private Vector3 _endBallPos = Vector3.zero;
    private Vector3 _initialPosition;

    private float _ballVelocity = 0;
    private float _swipeDistance = 0;
    private float _swipeTime = 0;
    private float _startHoldingTime = 0;
    private float _endHoldingTime = 0;

    private bool _isHolding = false;
    private bool _thrown = false;

    private void Start()
    {
        Initialized();
    }

    private void Update()
    {
        if (_isHolding)
        {
            PickUpBall();
        }
        else if (_thrown)
        {
            if (gameObject.transform.position.y < 1)
            {
                ResetBall();
            }
        }
    }

    private void Initialized()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _initialPosition = gameObject.transform.position;
        ResetBall();
    }

    public void ResetBall()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.useGravity = false;
        _isHolding = false;
        _thrown = false;

        gameObject.transform.position = _initialPosition;
    }

    private void HoldBall()
    {
        _startHoldingTime = Time.time;
        _startBallPos = Input.mousePosition;
        _rigidbody.useGravity = false;
        _isHolding = true;
    }

    private void PickUpBall()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane * 30f;
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePos);
        gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, newPosition, 80f * Time.deltaTime);
    }

    private void ThrowBall()
    {
        _rigidbody.useGravity = true;

        _endHoldingTime = Time.time;

        _endBallPos = Input.mousePosition;
        _swipeDistance = (_endBallPos - _startBallPos).magnitude;
        _swipeTime = _endHoldingTime - _startHoldingTime;

        Vector3 swipeAngle = calculateAngle();
        float ballSpeed = CalculateSpeed();

        _rigidbody.AddForce(new Vector3((swipeAngle.x * ballSpeed), (swipeAngle.y * ballSpeed), (swipeAngle.z * ballSpeed)));

        _isHolding = false;
        _thrown = true;
    }

    private Vector3 calculateAngle()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(_endBallPos.x, _endBallPos.y + 50f, (Camera.main.nearClipPlane + 20f)));
    }

    private float CalculateSpeed()
    {
        if (_swipeTime > 0f)
        {
            _ballVelocity = _swipeDistance / (_swipeDistance - _swipeTime);
            return _ballVelocity * 40f;
        }

        return 0f;
    }

    void OnMouseDown()
    {
        HoldBall();
    }

    void OnMouseUp()
    {
        ThrowBall();
    }


}
