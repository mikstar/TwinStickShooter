using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

	protected GameObject[] players;
	protected float[] threatCounts;
	protected int targetIndx = 0;
	public float attackDelay;
	protected float currentAttackDelay = 0;
	public int attackDmg;
	
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		threatCounts = new float[players.Length];
	}

	public void addThreat(int dmg,Transform source)
	{
		for(int i=0;i<players.Length;i++)
		{
			if(players[i] == source.gameObject)
			{
				threatCounts[i] += dmg;
				if(threatCounts[i] > threatCounts[targetIndx]*1.3f)
				{
					targetIndx = i;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

		for(int i=0;i<threatCounts.Length;i++)
		{
			threatCounts[i] = threatCounts[i]*0.97f;
		}
		currentAttackDelay -= Time.deltaTime;
		movement();
	}

	protected  virtual void movement()
	{

	}
	protected void attack(GameObject target)
	{
		target.GetComponent<HealthSystem>().ChangeHealth(attackDmg,transform);
	}
}
