using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public int maxhealth;
	protected int currentHealth;

	protected virtual void Start()
	{
		currentHealth = maxhealth;
	}

	public virtual void ChangeHealth(int dmg, Transform source)
	{
		currentHealth = Mathf.Clamp(currentHealth-dmg,0,maxhealth);
		if(currentHealth == 0)
		{
			Destroy(gameObject);
		}
		Debug.Log(currentHealth);
	}
}
