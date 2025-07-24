using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callMinion : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public Wave[] waves;
	public GameObject[] Enemy;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;

	void Start() {
		//NextWave();
	}

	void Update() {

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
			int spawnIndex=Random.Range(0, SpawnPoints.Length);
			int objIndex=Random.Range(0, Enemy.Length);
			GameObject enemyObject = Instantiate(Enemy[objIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
			enemy spawnedEnemy = enemyObject.GetComponent<enemy>();
			// Check if the spawned enemy has the MiniBoss tag
			if (enemyObject.CompareTag("Medkit"))
			{
				Medkit spawnedMedkit = enemyObject.GetComponent<Medkit>();
			} else
        	{
				spawnedEnemy.OnDeath += OnEnemyDeath;
			}
		}
	}

	void OnEnemyDeath() {
		enemiesRemainingAlive --;

		if (enemiesRemainingAlive == 0) {
			NextWave();
		}
	}

	public void NextWave() {
		currentWaveNumber ++;
		if (currentWaveNumber - 1 < waves.Length) {
			currentWave = waves [currentWaveNumber - 1];

			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}
	}

	[System.Serializable]
	public class Wave {
		public int enemyCount;
		public float timeBetweenSpawns;
	}
}