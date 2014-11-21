using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponTestGun : WeaponBase {
	
	public Mesh bulletModel;
	public Material bulletMaterial;
	public int bulletDamage;
	public float bulletSpeed;

	public override void fire(Transform firePoint)
	{
		GameObject bullet = new GameObject();
		MeshRenderer rend =  bullet.AddComponent<MeshRenderer>();
		rend.material = bulletMaterial;
		rend.castShadows = false;
		rend.receiveShadows = false;
		bullet.AddComponent<MeshFilter>().mesh = bulletModel;
		bullet.transform.position = firePoint.transform.position;
		bullet.AddComponent<BasicProjectile>().setStats(bulletDamage,bulletSpeed,firePoint);
		bullet.transform.eulerAngles = firePoint.transform.eulerAngles;
		bullet.AddComponent<SphereCollider>().isTrigger = true;
		bullet.AddComponent<Rigidbody>().isKinematic = true;
		bullet.transform.localScale = bullet.transform.localScale / 3;
		bullet.layer = 12;
	}
}
