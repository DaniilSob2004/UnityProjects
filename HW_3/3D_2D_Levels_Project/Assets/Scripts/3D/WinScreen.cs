using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private CanvasGroup winScreen;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private int nextSceneIndex;

    private void OnEnable()
    {
        score.OnScoreUpdate += OnScoreUpdate;
        restartBtn.onClick.AddListener(OnRestartButtonClick);
        nextLevelBtn.onClick.AddListener(OnNextLevelButtonClick);
    }

    private void OnDisable()
    {
        score.OnScoreUpdate -= OnScoreUpdate;
        restartBtn.onClick.RemoveListener(OnRestartButtonClick);
        nextLevelBtn.onClick.RemoveListener(OnNextLevelButtonClick);
    }

    private void OnScoreUpdate()
    {
        winScreen.alpha = 1f;
        winScreen.interactable = true;
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnNextLevelButtonClick()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
