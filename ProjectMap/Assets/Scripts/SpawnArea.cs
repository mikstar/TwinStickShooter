using UnityEngine;
using System.Collections;

public class SpawnArea : MonoBehaviour {

	public EnemySpawner[] spawners;
	private int playerCount = 0;

	void OnTriggerEnter(Collider col)
	{
		playerCount++;
		if(playerCount == 1)
		{
			foreach(EnemySpawner spw in spawners)
			{
				spw.spawning = true;
			}
		}
	}
	void OnTriggerExit(Collider col)
	{
		playerCount--;
		if(playerCount == 0)
		{
			foreach(EnemySpawner spw in spawners)
			{
				spw.spawning = false;
			}
		}
	}
}
