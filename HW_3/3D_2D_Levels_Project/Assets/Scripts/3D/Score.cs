using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreText;  // ссылка на компонент текстового UI элемента, использующего TextMeshPro

    private List<Dirt> dirts;
    private int scoreValue;

    public event UnityAction OnScoreUpdate;

    private void Start()
    {
        dirts = new List<Dirt>(FindObjectsOfType<Dirt>());  // находим все объекты с компонентом "Dirt"
    }

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
        scoreValue++;

        var activeDirts = dirts.FindAll(dirt => dirt.gameObject.activeSelf);  // находим объекты которые есть на сцене (активные)
        
        if (activeDirts.Count == 0)
        {
            OnScoreUpdate?.Invoke();
            scoreText.gameObject.SetActive(false);
        }
        else
        {
            scoreText.text = $"Score: {scoreValue}";
        }
    }
}
