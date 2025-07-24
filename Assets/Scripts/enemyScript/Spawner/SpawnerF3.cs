using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerF3 : MonoBehaviour
{
	public Transform[] SpawnPoints;
	public Wave[] waves;
	public GameObject[] Enemy;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;
	
    //------------GameObject------------
    public GameObject nextFloor;
	public GameObject gateFloor;
	public GameObject WinUI;

	void Start()
	{
		gateFloor.GetComponent<Collider>().enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag=="Player")
		{
			NextWave();
			//Destroy(gameObject,5f);
			gameObject.GetComponent<BoxCollider>().enabled=false;
			gateFloor.GetComponent<Collider>().enabled=true;
		}
	}

	void Update() {

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
			
			//Random Position Spawn
			int spawnIndex=Random.Range(0, SpawnPoints.Length);
			int objIndex=Random.Range(0, Enemy.Length);
			
            GameObject enemyObject = Instantiate(Enemy[objIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
			
			// Check if the spawned enemy has the MiniBoss tag
			if (enemyObject.CompareTag("MiniBoss"))
			{
				MB_health spawnedMiniBoss = enemyObject.GetComponent<MB_health>();
				if (spawnedMiniBoss != null)
				{
					spawnedMiniBoss.OnDeath += OnEnemyDeath;
				}
			} else
        	{
            	enemy spawnedEnemy = enemyObject.GetComponent<enemy>();
				spawnedEnemy.OnDeath += OnEnemyDeath;
			}
        }
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;

        if (enemiesRemainingAlive == 0 && currentWaveNumber == waves.Length)
        {

			// Semua musuh telah dikalahkan dan wave telah habis, tampilkan UI WinCanvas
			Invoke("ActivateWinUI", 5f);
		}
        else if (enemiesRemainingAlive == 0)
        {
            // Jika semua musuh telah dikalahkan dalam wave saat ini, lanjutkan ke wave berikutnya
            NextWave();
            NextFloor();
        }
    }

	void ActivateWinUI()
	{
		ScriptScene scriptScene = GameObject.Find("Win").GetComponent<ScriptScene>();

		scriptScene.Finish();
		Time.timeScale = 0;
	}

	void NextFloor()
	{
		nextFloor.GetComponent<Collider>().enabled=false;
		print ("Next Floor");
	}


	void NextWave() {
		currentWaveNumber ++;
		print ("Wave: " + currentWaveNumber);
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
