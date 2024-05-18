using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab; // エネミーのプレハブ
    public float timeBetweenWaves = 10f; // 波の間隔（秒）
    private float countdown = 2f; // 次の波までのカウントダウン

    public Transform spawnPoint; // エネミーの生成地点

    private int waveNumber = 0; // 現在の波の番号

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); // 次のエネミー生成までの間隔
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
