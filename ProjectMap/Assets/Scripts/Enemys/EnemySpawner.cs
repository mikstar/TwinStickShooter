using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public int maxEnemys;
	public float spawnDelay;
	private float spawnDelayLeft = 0;
	private GameObject[] enemys;
	public bool spawning = false;


	void Start () {
		enemys = new GameObject[maxEnemys];
		for(int i=0;i<maxEnemys;i++)
		{
			enemys[i] = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
			enemys[i].GetComponent<EnemyBase>().spawner = transform;
			enemys[i].SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
		CodeProfiler.Begin("Spawner:update");
		if(spawning)
		{
			spawnDelayLeft -= Time.deltaTime;
			if(spawnDelayLeft < 0)
			{
				CodeProfiler.Begin("Spawn");
				spawnDelayLeft += spawnDelay;
				foreach(GameObject enim in enemys)
				{
					if(!enim.activeSelf)
					{
						enim.SetActive(true);
						break;
					}
				}
				CodeProfiler.End("Spawn");
			}
		}
		CodeProfiler.End("Spawner:update");
	}
}
