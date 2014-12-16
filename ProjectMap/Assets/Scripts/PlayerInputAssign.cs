using UnityEngine;
using System.Collections;

public class PlayerInputAssign : MonoBehaviour {

	public int playernum;
	public PlayerMovement moveScr;
	public WeaponManager wepMngr;

	// Use this for initialization
	void Start () {
		int cntrlnum = PlayerPrefs.GetInt("player" + playernum + "cntrl");
		Debug.Log("num =" + cntrlnum);
		if(cntrlnum == 0)
		{
			Destroy(gameObject);
		}
		else
		{
			moveScr.setInput(cntrlnum);
			wepMngr.setInput(cntrlnum);
			Destroy(this);
		}
	}

}
