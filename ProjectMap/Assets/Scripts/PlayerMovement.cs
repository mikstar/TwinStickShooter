using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private string InptHor;
	private string InptVer;
	private string InptAimHor;
	private string InptAimVer;
	private GameObject aimBase;

	delegate void AimTurn();
	AimTurn aimTurn;

	void Start()
	{
		aimBase = transform.GetChild(0).gameObject;

	}

	// Update is called once per frame
	void Update () 
	{
		CodeProfiler.Begin("PlayMove:update");
		//turn/move the moveBase
		if(Input.GetAxis(InptHor) != 0 || Input.GetAxis(InptVer) != 0)
		{
			Vector3 aimDir = aimBase.transform.eulerAngles;
			float rotation = Mathf.Atan2(Input.GetAxis(InptHor),Input.GetAxis(InptVer))*Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0,rotation,0);
			aimBase.transform.eulerAngles = aimDir;
			rigidbody.AddRelativeForce(new Vector3(0,0,(1600*speed)*Time.deltaTime));
		}
		//turn the aimBase
		aimTurn();
		CodeProfiler.End("PlayMove:update");


	}

	public void setInput(int num)
	{
		if(num == -1)
		{
			InptHor = "Khor";
			InptVer= "Kver";
			aimTurn = mouseAim;
		}
		else
		{
			
			InptHor = "J" + num + "hor";
			InptVer = "J" + num + "ver";
			InptAimHor = "J" + num + "horAim";
			InptAimVer = "J" + num + "verAim";
			aimTurn = stickAim;
		}
	}

	private void stickAim()
	{
		if(Input.GetAxis(InptAimHor) != 0 || Input.GetAxis(InptAimVer) != 0)
		{
			float rotation = Mathf.Atan2(Input.GetAxis(InptAimVer),Input.GetAxis(InptAimHor))*Mathf.Rad2Deg;
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









