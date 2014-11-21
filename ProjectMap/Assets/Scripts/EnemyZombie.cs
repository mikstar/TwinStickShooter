using UnityEngine;
using System.Collections;

public class EnemyZombie : EnemyBase {

	protected  override void movement()
	{
		Vector3 delta = players[targetIndx].transform.position - transform.position;
		if(delta.magnitude > 1.6f)
		{
			transform.eulerAngles = new Vector3(0,Mathf.Atan2(delta.x,delta.z)*Mathf.Rad2Deg,0);
			rigidbody.AddRelativeForce(new Vector3(0,0,35));
		}
		else if(currentAttackDelay < 0)
		{
			currentAttackDelay = attackDelay;
			attack(players[targetIndx]);
		}

	}
}
