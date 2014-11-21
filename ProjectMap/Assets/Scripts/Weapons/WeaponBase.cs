using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponBase : ScriptableObject{

	protected int ammo;

	// Use this for initialization
	void Start () {

	}

	public virtual void fire(Transform firePoint)
	{

	}

	public virtual void release()
	{
		
	}
}
