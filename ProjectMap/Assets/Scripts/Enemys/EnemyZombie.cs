using UnityEngine;
using System.Collections;

public class EnemyZombie : EnemyBase {

	protected  override void movement()
	{
		Vector3 delta = players[targetIndx].transform.position - getTF.position;
		if(delta.magnitude > 1.6f)
		{
			getTF.eulerAngles = new Vector3(0,Mathf.Atan2(delta.x,delta.z)*Mathf.Rad2Deg,0);
			getRB.AddRelativeForce(new Vector3(0,0,1600*Time.deltaTime));
		}
		else if(currentAttackDelay < 0)
		{
			currentAttackDelay = attackDelay;
			attack(players[targetIndx]);
		}

	}
}
