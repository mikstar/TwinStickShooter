using UnityEngine;
using System.Collections;

public class HealthSysyemEnemys : HealthSystem {

	private EnemyBase coreScript;

	protected override void Start()
	{
		currentHealth = maxhealth;
		coreScript = GetComponent<EnemyBase>();
	}

	public override void ChangeHealth(int dmg, Transform source)
	{
		currentHealth = Mathf.Clamp(currentHealth-dmg,0,maxhealth);
		if(currentHealth == 0)
		{
			transform.position = coreScript.spawner.position;
			currentHealth = maxhealth;
			gameObject.SetActive(false);
		}
		else
		{
			coreScript.addThreat(dmg,source);
		}
	}
}
