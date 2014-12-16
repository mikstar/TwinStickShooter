using UnityEngine;
using System.Collections;

public class WeaponMachineGun : WeaponBase {

	protected override void fire()
	{
		RaycastHit hit;
		Debug.DrawRay(firePoint.position + firePointOffset,firePoint.forward*10);
		Debug.Log(firePoint.forward);
		if(Physics.Raycast(firePoint.position + firePointOffset,firePoint.forward, out hit,1000,1<<10))
		{
			hit.collider.gameObject.GetComponent<HealthSystem>().ChangeHealth(bulletDamage,firePoint);
		}
	}
}
