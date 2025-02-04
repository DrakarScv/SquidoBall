using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private ScoreUIView _scoreUIView;
    [SerializeField] private HoopTrigger _hoopTrigger;
    [SerializeField] private BasketballHoopController _basketballHoopController;

    [SerializeField] private GameObject _squidoBallPrefab;
    [SerializeField] private Vector3 _ballStartingPosition;

    [SerializeField] private Button _resetButton;

    private BallControler _squidoBall = null;

    void Start()
    {
        CreateSquidoBall();

        _scoreUIView.ResetScore();

        _hoopTrigger.Initialize(_squidoBall.gameObject);
        _hoopTrigger.RegisterOnGoalAction(_scoreUIView.IncrementScore);

        _resetButton.onClick.AddListener(ResetGame);
    }

    private void CreateSquidoBall()
    {
        GameObject GO = Instantiate(_squidoBallPrefab);
        _squidoBall = GO.GetComponent<BallControler>();

        _squidoBall.transform.position = _ballStartingPosition;
    }

    private void ResetGame()
    {
        _scoreUIView.ResetScore();
        _basketballHoopController.ResetHoopController();

        _squidoBall.ResetBall();

        _squidoBall.transform.position = _ballStartingPosition;
    }
}
