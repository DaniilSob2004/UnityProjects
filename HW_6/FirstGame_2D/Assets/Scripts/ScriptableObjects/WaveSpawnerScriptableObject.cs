using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawner/NewWave", fileName = "NewWave")]
public class WaveSpawnerScriptableObject : ScriptableObject
{
    [SerializeField] private int waveNumber;
    [SerializeField] private List<UnitMover> templates;
    [SerializeField] private int spawnSize;
    [SerializeField] private float spawnDelay;
    [SerializeField] private int spawnPositionRange;
    [SerializeField] private float waveDuration;

    public int WaveNumber => waveNumber;
    public List<UnitMover> Templates => templates;
    public int SpawnSize => spawnSize;
    public float SpawnDelay => spawnDelay;
    public int SpawnPositionRange => spawnPositionRange;
    public float WaveDuration => waveDuration;
}
