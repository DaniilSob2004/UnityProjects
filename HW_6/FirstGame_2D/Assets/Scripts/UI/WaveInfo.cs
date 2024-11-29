using TMPro;
using UnityEngine;

public class WaveInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Spawner spawner;

    private void OnEnable()
    {
        spawner.OnWaveSpawned += OnWaveSpawned;
    }

    private void OnDisable()
    {
        spawner.OnWaveSpawned -= OnWaveSpawned;
    }

    private void OnWaveSpawned(int waveNumber)
    {
        text.text = $"Wave: {waveNumber}";
    }
}
