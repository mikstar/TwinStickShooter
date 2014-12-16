using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponBase : ScriptableObject{

	protected Transform firePoint;
	protected int ammo;
	public int bulletDamage;
	public float bulletSpeed;
	public float maxBulletSpread;
	public float minBulletSpread;
	protected float currentBulletSpread = 0;
	public float bulletSpreadIncrease;
	private bool fireing;
	public float fireDelay;
	private float fireDelayLeft = 0;
	protected Vector3 firePointOffset = new Vector3(0,2,0.5f);
	
	public void setFPoint(Transform Fpnt)
	{
		firePoint = Fpnt;
	}

	public virtual void press()
	{
		fireing = true;
	}

	protected virtual void fire()
	{

	}

	public virtual void release()
	{
		fireing = false;
	}

	public void wepUpdate()
	{
		fireDelayLeft -= Time.deltaTime;

		if(fireing)
		{
			if(fireDelayLeft < 0)
			{
				fireDelayLeft = fireDelay;
				fire();
			}
			currentBulletSpread += bulletSpreadIncrease*Time.deltaTime;
		}
		else
		{
			currentBulletSpread -= bulletSpreadIncrease*Time.deltaTime;
		}
		currentBulletSpread = Mathf.Clamp(currentBulletSpread,minBulletSpread,maxBulletSpread);
	}
}
