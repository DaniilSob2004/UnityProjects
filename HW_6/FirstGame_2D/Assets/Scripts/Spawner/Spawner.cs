using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    // волна разных prefabs
    [SerializeField] private List<WaveSpawnerScriptableObject> wavesData;
    
    private List<UnitMover> spawnedUnits = new List<UnitMover>();
    private float timeToSpawn;
    private float timeToNextWave;
    private int currentWaveIndex;

    public event UnityAction<int> OnWaveSpawned;
    public event UnityAction OnAllWavesFinished;
    
    private void Start()
    {
        InitializeSpawn(wavesData[currentWaveIndex]);  // первая волна
    }

    private void Update()
    {
        ActiveSelfChecker(wavesData[currentWaveIndex]);
        NextWaveChecker();
    }

    private void InitializeSpawn(WaveSpawnerScriptableObject wave)
    {
        for (var i = 0; i < wave.SpawnSize; i++)
        {
            var newUnit = Instantiate(GetRandomUnit(wave), RandomPosition(wave), Quaternion.identity);
            newUnit.gameObject.SetActive(false);
            spawnedUnits.Add(newUnit);
        }
        OnWaveSpawned?.Invoke(wavesData[currentWaveIndex].WaveNumber);
    }

    private void ActiveSelfChecker(WaveSpawnerScriptableObject wave)
    {
        timeToSpawn += Time.deltaTime;

        foreach (var unit in spawnedUnits)
        {
            if (!unit.gameObject.activeSelf && timeToSpawn >= wave.SpawnDelay)
            {
                unit.transform.position = RandomPosition(wave);
                unit.gameObject.SetActive(true);
                timeToSpawn = 0f;
            }
        }
    }

    private void NextWaveChecker()
    {
        // если время текущей волны истекло
        timeToNextWave += Time.deltaTime;
        if (timeToNextWave >= wavesData[currentWaveIndex].WaveDuration)
        {
            // очищаем список units
            foreach (var unit in spawnedUnits.ToList())
            {
                spawnedUnits.Remove(unit);
                Destroy(unit.gameObject);
            }

            // создаём новую (следующию волну)
            if (currentWaveIndex < wavesData.Count - 1)
            {
                currentWaveIndex++;
                InitializeSpawn(wavesData[currentWaveIndex]);
                timeToNextWave = 0f;
                OnWaveSpawned?.Invoke(wavesData[currentWaveIndex].WaveNumber);
            }
            else
            {
                OnAllWavesFinished?.Invoke();
            }
        }
    }

    private UnitMover GetRandomUnit(WaveSpawnerScriptableObject wave)
    {
        return wave.Templates[Random.Range(0, wave.Templates.Count)];
    }
    
    private Vector2 RandomPosition(WaveSpawnerScriptableObject wave)
    {
        return new Vector2(transform.position.x, Random.Range(-wave.SpawnPositionRange, wave.SpawnPositionRange));
    }
}
