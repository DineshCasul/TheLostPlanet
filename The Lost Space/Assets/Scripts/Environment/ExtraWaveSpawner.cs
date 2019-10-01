using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraWaveSpawner : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    };
    [System.Serializable]
    public class wave
    {
        public string WaveName;
        public Transform[] Item;
        public float count;
        public float rate;
    }
    public wave[] waves;
    public float timebtwWaves = 0f;
    public float waveCountdown = 5f;
    public int nextWave = 0;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;
    public Transform[] SpawnPoints;
    public Animator WaveTextAnim;
    private WaveNumber waveNumber;

    void Start()
    {
        if (SpawnPoints.Length == 0)
        {
            Debug.LogError("No spawnpoints Referenced");
        }
        waveCountdown = timebtwWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWaves(waves[nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }
    IEnumerator SpawnWaves(wave _wave)
    {
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.Item[Random.Range(0, 3)]);
            yield return new WaitForSeconds(1 / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("EnemySpawning" + _enemy.name);
        Transform _spawnpoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_enemy, _spawnpoint.position, Quaternion.identity);
    }


    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 2f;
            if (GameObject.FindGameObjectWithTag("Astroids") == null)
            {


                return false;

            }
        }
        return true;
    }
    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timebtwWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed All waves!!");
        }
        else
        {
            waveNumber.wavenumber += 1;
            WaveTextAnim.SetTrigger("nextWave");
            nextWave++;
        }

    }
}
