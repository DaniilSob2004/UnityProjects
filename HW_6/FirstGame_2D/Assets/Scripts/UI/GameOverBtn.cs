using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverBtn : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private int sceneIndex;

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
