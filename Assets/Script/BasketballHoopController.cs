using System.Collections.Generic;
using UnityEngine;

public class BasketballHoopController : MonoBehaviour
{
    [SerializeField] private GameObject _basketHoop;

    [SerializeField] private List<GameObject> _basketHoopPositionList;

    private float _changeHoopPlaceTimer = 5f;
    private float _cooldown = 0f;
    private int _currentPosition = 0;

    private void Update()
    {
        if (_cooldown >= _changeHoopPlaceTimer)
        {
            _currentPosition = (_currentPosition + 1) % _basketHoopPositionList.Count;
            _basketHoop.transform.position = _basketHoopPositionList[_currentPosition].transform.position;

            _cooldown = 0;
        }

        _cooldown += Time.deltaTime;
    }

    public void ResetHoopController()
    {
        _cooldown = 0;
        _basketHoop.transform.position = _basketHoopPositionList[0].transform.position;
    }
}
