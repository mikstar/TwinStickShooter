using UnityEngine;
using System.Collections;

public class CharselectTab : MonoBehaviour {

	private int controllerNum;
	private string selectButtnName;
	private CharselectControllerRegester controller;
	private bool ready;
	private Renderer rend;

	void Start()
	{
		rend = gameObject.GetComponent<MeshRenderer>();
	}

	public void setController(CharselectControllerRegester cntrl)
	{
		controller = cntrl;
	}
	public void setCntrlNum(int num)
	{
		controllerNum = num;
		if(num == 0)
		{
			rend.enabled = false;
		}
		else if(num == -1)
		{
			selectButtnName = "Kselect";
			rend.enabled = true;

		}
		else
		{
			selectButtnName = "J"+num+"select";
			rend.enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if(controllerNum != 0 && Input.GetButtonDown(selectButtnName))
		{
			ready = !ready;
			if(ready)
			{
				transform.localScale = new Vector3(0.5f,0.5f,0.5f);
				controller.playersReady++;
				Debug.Log("controller " + controllerNum + " ready");
			}
			else
			{
				transform.localScale = new Vector3(1,1,1);
				controller.playersReady--;
				Debug.Log("controller " + controllerNum + " not ready");
			}
		}
	}
}
