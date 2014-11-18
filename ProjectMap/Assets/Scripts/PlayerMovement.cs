using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public string InptHor;
	public string InptVer;
	public string InptAimHor;
	public string InptAimVer;
	private GameObject aimBase;

	delegate void AimTurn();
	AimTurn aimTurn;

	void Start()
	{
		aimBase = transform.GetChild(0).gameObject;

		if(InptAimHor == "Mouse")
		{
			aimTurn = mouseAim;
		}
		else
		{
			aimTurn = stickAim;
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		//turn/move the moveBase
		if(Input.GetAxis(InptHor) != 0 || Input.GetAxis(InptVer) != 0)
		{
			float rotation = Mathf.Atan2(Input.GetAxis(InptHor),Input.GetAxis(InptVer))*Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0,rotation,0);
			rigidbody.AddRelativeForce(new Vector3(0,0,45*speed));
		}
		//turn the aimBase
		aimTurn();


	}

	private void stickAim()
	{
		if(Input.GetAxis(InptHor) != 0 || Input.GetAxis(InptVer) != 0)
		{
			float rotation = Mathf.Atan2(Input.GetAxis(InptAimHor),Input.GetAxis(InptAimVer))*Mathf.Rad2Deg;
			aimBase.transform.eulerAngles = new Vector3(0,rotation,0);
		}
	}

	private void mouseAim()
	{
		Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 aimPoint = Physics.RaycastAll(ray,100,(1<<8))[0].point;
		Vector3 delta = aimPoint - transform.position;
		aimBase.transform.eulerAngles = new Vector3(0,Mathf.Atan2(delta.x,delta.z)*Mathf.Rad2Deg,0);
	}
}









