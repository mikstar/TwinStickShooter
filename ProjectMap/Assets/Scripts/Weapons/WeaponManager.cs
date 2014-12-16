using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

	private string inptWepChnge;
	private string inptFire;
	private int wepIndx = 0;
	public List<WeaponBase> weapons;
	private bool fireing = false;
	private bool changing = false;

	delegate void FireCheck();
	FireCheck fireCheck;

	// Use this for initialization
	void Start () {
		for(int i=0;i<weapons.Count;i++)
		{
			weapons[i] = Object.Instantiate(weapons[i]) as WeaponBase;
			weapons[i].setFPoint(transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		CodeProfiler.Begin("WepHandle:update");
		if(Input.GetButtonDown(inptWepChnge))
		{
			if(Input.GetAxis(inptWepChnge) > 0)
			{
				weapons[wepIndx].release();
				wepIndx ++;
				if(wepIndx == weapons.Count)
				{
					wepIndx = 0;
				}
			}
			else
			{
				weapons[wepIndx].release();
				wepIndx --;
				if(wepIndx < 0)
				{
					wepIndx = weapons.Count - 1;
				}

			}
		}
		weapons[wepIndx].wepUpdate();
		fireCheck();
		CodeProfiler.End("WepHandle:update");
	}

	public void setInput(int num)
	{
		if(num == -1)
		{
			inptWepChnge = "KwepChnge";
			fireCheck = mouseFireCheck;
		}
		else
		{
			
			inptWepChnge = "J" + num + "wepChnge";
			inptFire = "J" + num + "Fire";
			fireCheck = padFireCheck;
		}
	}

	private void mouseFireCheck()
	{
		if(Input.GetMouseButtonDown(0))
		{
			weapons[wepIndx].press();
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
		else if(!fireing && Input.GetAxis(inptFire) == 1)
		{
			weapons[wepIndx].press();
			fireing = true;
		}
	}
}











