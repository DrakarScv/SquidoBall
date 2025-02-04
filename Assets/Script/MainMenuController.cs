using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;

    void Start()
    {
        Initialize();
    }

    private void Initialize() 
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    private void OnPlayButtonClick() 
    {
       SceneManager.LoadScene("Game");
    }

    private void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
