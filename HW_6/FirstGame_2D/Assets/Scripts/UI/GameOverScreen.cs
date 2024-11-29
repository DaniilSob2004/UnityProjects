using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text waveInfoText;

    private void OnEnable()
    {
        spawner.OnAllWavesFinished += OnAllWavesFinished;
    }

    private void OnDisable()
    {
        spawner.OnAllWavesFinished -= OnAllWavesFinished;
    }

    private void OnAllWavesFinished()
    {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1.0f;
        gameOverText.text = "You WIN!";
        waveInfoText.gameObject.SetActive(false);
    }
}
