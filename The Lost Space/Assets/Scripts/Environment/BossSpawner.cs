using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawner : MonoBehaviour
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
        public Transform []Enemy;
        public float count;
        public float rate;
    }
    public wave[] waves;
    public float timebtwWaves = 0f;
    public float waveCountdown = 5f;
   private int nextWave = 0;
    private float searchCountdown = 5f;
    private SpawnState state = SpawnState.COUNTING;
    public Transform[] SpawnPoints;
    public Animator WaveTextAnim;
    public Animator LastWaveAnim;
    private WaveNumber waveNumber;
    public Animator TransitionAnim;

    void Start()
    {
        if(SpawnPoints.Length == 0)
        {
            Debug.LogError("No spawnpoints Referenced");
        }
        waveCountdown = timebtwWaves;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
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
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWaves (waves[nextWave]));
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
            SpawnEnemy(_wave.Enemy[Random.Range(0,1)]);  //only one enemy can spawn i.e BOSS
            yield return new WaitForSeconds(1 / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        
        Transform _spawnpoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_enemy, _spawnpoint.position, Quaternion.identity);
        Debug.Log("EnemySpawning" + _enemy.name);
    }


    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 5f;
            if (GameObject.FindGameObjectWithTag("Charon") == null)
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
        if(nextWave +1 > waves.Length - 1)
        {
            waveCountdown = 100;
           // StartCoroutine(Outro());
        }
        else
        {
            waveNumber.wavenumber += 1;
            WaveTextAnim.SetTrigger("nextWave");
            nextWave++;
            
        }
       
    }
   /* IEnumerator Outro()
    {
       
        TransitionAnim.SetTrigger("ChangeScene");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Outro1");
    }*/
}
