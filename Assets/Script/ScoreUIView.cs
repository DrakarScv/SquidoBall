using UnityEngine;
using TMPro;

public class ScoreUIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = $"Score : {_score}";
    }

    public void IncrementScore() 
    {
        _score += 1;
        _scoreText.text = $"Score : {_score}";
    }
}
