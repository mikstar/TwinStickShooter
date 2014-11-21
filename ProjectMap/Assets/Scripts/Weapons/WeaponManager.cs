using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

	public string inptWepChnge;
	public string inptFire;
	private int wepIndx = 0;
	public List<WeaponBase> weapons;
	private bool fireing = false;

	delegate void FireCheck();
	FireCheck fireCheck;

	// Use this for initialization
	void Start () {
		if(inptFire == "Mouse")
		{
			fireCheck = mouseFireCheck;
		}
		else
		{
			fireCheck = padFireCheck;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis(inptWepChnge) == 1)
		{
			wepIndx ++;
			if(wepIndx == weapons.Count)
			{
				wepIndx = 0;
			}
		}
		else if(Input.GetAxis(inptWepChnge) == -1)
		{
			wepIndx --;
			if(wepIndx < 0)
			{
				wepIndx = weapons.Count - 1;
			}
		}

		fireCheck();
	}

	private void mouseFireCheck()
	{
		if(Input.GetMouseButtonDown(0))
		{
			weapons[wepIndx].fire(transform);
		}
		else if(Input.GetMouseButtonUp(0))
		{
			weapons[wepIndx].release();
		}
	}
	private void padFireCheck()
	{

		if(fireing && Input.GetAxis(inptFire) == 0)
		{
			weapons[wepIndx].release();
			fireing = false;
		}
		else if(Input.GetAxis(inptFire) == 1)
		{
			weapons[wepIndx].fire(transform);
			fireing = true;
		}
	}
}











