using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreText;  // ������ �� ��������� ���������� UI ��������, ������������� TextMeshPro

    private int _scoreValue;

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
        _scoreValue++;
        scoreText.text = $"Score: {_scoreValue}";
    }
}
