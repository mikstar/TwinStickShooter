using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponTestGun : WeaponBase {
	
	public Mesh bulletModel;
	public Material bulletMaterial;

	protected override void fire()
	{
		CodeProfiler.Begin("Fire_Bullet");
		GameObject bullet = new GameObject();
		MeshRenderer rend =  bullet.AddComponent<MeshRenderer>();
		rend.material = bulletMaterial;
		rend.castShadows = false;
		rend.receiveShadows = false;
		bullet.AddComponent<BasicProjectile>().setStats(bulletDamage,bulletSpeed,firePoint);
		bullet.AddComponent<MeshFilter>().mesh = bulletModel;
		bullet.AddComponent<Rigidbody>().isKinematic = true;
		bullet.AddComponent<SphereCollider>().isTrigger = true;
		Transform tempTrans = bullet.transform;
		tempTrans.position = firePoint.transform.position + firePointOffset;
		tempTrans.eulerAngles = firePoint.eulerAngles + new Vector3(0,Random.Range(-currentBulletSpread,currentBulletSpread),0);
		tempTrans.localScale = tempTrans.localScale / 3;
		bullet.layer = 12;
		CodeProfiler.End("Fire_Bullet");
	}
}
