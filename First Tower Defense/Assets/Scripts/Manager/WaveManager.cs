using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab; // �G�l�~�[�̃v���n�u
    public float timeBetweenWaves = 10f; // �g�̊Ԋu�i�b�j
    private float countdown = 2f; // ���̔g�܂ł̃J�E���g�_�E��

    public Transform spawnPoint; // �G�l�~�[�̐����n�_

    private int waveNumber = 0; // ���݂̔g�̔ԍ�

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
            yield return new WaitForSeconds(0.5f); // ���̃G�l�~�[�����܂ł̊Ԋu
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
