using UnityEngine;
using System.Collections;

public class SpawnerF1 : MonoBehaviour 
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
	public GameObject Nextstage;
	public GameObject pintu;
	public GameObject Medkit;

	void Start()
	{
		gateFloor.GetComponent<Collider>().enabled = false;
		Nextstage.SetActive(false);
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
			Nextstage.SetActive(true);
				pintu.SetActive(false);
			Medkit.SetActive(true);
		}
		else if (enemiesRemainingAlive == 0)
		{
			// Jika semua musuh telah dikalahkan dalam wave saat ini, lanjutkan ke wave berikutnya
			NextWave();
			NextFloor();
		}
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