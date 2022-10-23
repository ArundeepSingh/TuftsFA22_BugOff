using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private SpawnState state = SpawnState.COUNTING;
    private float searchCountdown = 1f;

    void Start() {

        if (spawnPoints.Length == 0) {
            Debug.Log("No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;

    }

    void Update() {
        if (state == SpawnState.WAITING) {
            if (!EnemyIsAlive()) {
                WaveCompleted();
            } else {
                return;
            }
        }


        if (waveCountdown <= 0) {
            if (state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } else {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted() {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) {
            SceneManager.LoadScene("EndScene");
        } else {
            nextWave++;
        }
    }

    bool EnemyIsAlive() {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0) {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("EnemyRoach") == null &&
                GameObject.FindGameObjectWithTag("EnemyKnifeRoach") == null) {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave wave) {
        state = SpawnState.SPAWNING;
        
        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        
        state = SpawnState.WAITING;
        
        yield break;
    }

    void SpawnEnemy(Transform enemy) {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, Quaternion.identity);
    }
}
