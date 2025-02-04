using UnityEngine;
using UnityEngine.Events;

public class HoopTrigger : MonoBehaviour
{
    private GameObject _squidoBall = null;

    private UnityAction _onGoal; 
    public void Initialize(GameObject squidoBall)
    {
        _squidoBall = squidoBall;   
    }

    public void RegisterOnGoalAction(UnityAction onGoalAction)
    {
        _onGoal += onGoalAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_squidoBall = other.gameObject)
        {
            _onGoal?.Invoke();
        }
    }
}
