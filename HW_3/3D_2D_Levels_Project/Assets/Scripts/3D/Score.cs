using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreText;  // ������ �� ��������� ���������� UI ��������, ������������� TextMeshPro

    private List<Dirt> dirts;
    private int scoreValue;

    public event UnityAction OnScoreUpdate;

    private void Start()
    {
        dirts = new List<Dirt>(FindObjectsOfType<Dirt>());  // ������� ��� ������� � ����������� "Dirt"
    }

    //  ����������, ����� ������, �� ������� ����� ������ ������, ������������ � �����
    private void OnEnable()
    {
        player.OnDirtPickUp += SetScore;
    }

    // ����������, ����� ������ � ���� �������� ����������� ��� ������������
    private void OnDisable()
    {
        player.OnDirtPickUp -= SetScore;
    }

    private void SetScore()
    {
        scoreValue++;

        var activeDirts = dirts.FindAll(dirt => dirt.gameObject.activeSelf);  // ������� ������� ������� ���� �� ����� (��������)
        
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
