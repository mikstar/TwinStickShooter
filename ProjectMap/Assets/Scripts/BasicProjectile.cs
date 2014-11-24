using UnityEngine;
using System.Collections;

public class BasicProjectile : MonoBehaviour {

	private int damage;
	private float speed;
	private Transform source;

	public void setStats(int dmg, float spd,Transform srce)
	{
		speed = spd;
		damage = dmg;
		source = srce;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
	}
	void OnTriggerEnter(Collider col)
	{

		//layer 13 are walls/enviorment
		if(col.collider.gameObject.layer == 13)
		{
			//when hitting a wall
		}
		//else, assuming to hit a player or enemy
		else
		{
			col.collider.gameObject.GetComponent<HealthSystem>().ChangeHealth(damage,source);
		}

		Destroy(gameObject);
	}
}










