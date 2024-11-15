using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreText;  // ссылка на компонент текстового UI элемента, использующего TextMeshPro

    private int _scoreValue;

    //  вызывается, когда объект, на котором висит данный скрипт, активируется в сцене
    private void OnEnable()
    {
        player.OnDirtPickUp += SetScore;
    }

    // вызывается, когда объект с этим скриптом отключается или уничтожается
    private void OnDisable()
    {
        player.OnDirtPickUp -= SetScore;
    }

    private void SetScore()
    {
        _scoreValue++;
        scoreText.text = $"Score: {_scoreValue}";
    }
}
