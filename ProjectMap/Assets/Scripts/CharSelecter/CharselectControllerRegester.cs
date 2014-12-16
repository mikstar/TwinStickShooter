using UnityEngine;
using System.Collections;

public class CharselectControllerRegester : MonoBehaviour {

	private int[] assignedCntls = new int[]{0,0,0,0};
	public int playersReady = 0;
	public CharselectTab[] charTabs;

	// Use this for initialization
	void Start () {
		foreach(CharselectTab chr in charTabs)
		{
			chr.setController(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//check start on keyboard
		if(Input.GetButtonDown("KStart"))
		{
			bool taken = false;
			for(int j=0;j<assignedCntls.Length;j++)
			{
				if(assignedCntls[j] == -1)
				{
					taken = true;
					break;
					
				}
			}
			if(taken)
			{
				//unassighn one of the charscreens
			}
			else
			{
				//assighn one of the charscreens to keyboard
				for(int j=0;j<assignedCntls.Length;j++)
				{
					if(assignedCntls[j] == 0)
					{
						assignedCntls[j] = -1;
						charTabs[j].setCntrlNum(-1);
						Debug.Log("assign at K");
						break;
					}
				}

			}
		}
		else
		{
			//check all controllers if start was pressed
			for(int i=0;i<5;i++)
			{
				if(Input.GetButtonDown("J" + (i+1) + "Start"))
				{
					//check if this controller has already been assigned
					bool taken = false;
					for(int j=0;j<assignedCntls.Length;j++)
					{
						if(assignedCntls[j] == i+1)
						{
							taken = true;
							break;

						}
					}
					if(taken)
					{
						//unassign one of the charscreens
					}
					else
					{
						//assign one of the charscreens to controller
						for(int j=0;j<assignedCntls.Length;j++)
						{
							if(assignedCntls[j] == 0)
							{
								assignedCntls[j] = i+1;
								charTabs[j].setCntrlNum(i+1);
								Debug.Log("assign at "+i+1);
								break;
							}
						}
					}

				}
				
			}


			//check if all players are ready, if so, start game
			int plrsInScreen = 0;
			foreach(int i in assignedCntls)
			{
				if(i != 0)
				{
					plrsInScreen++;
				}
			}

			if(plrsInScreen>0 && playersReady == plrsInScreen)
			{
				for(int i=0;i<assignedCntls.Length;i++)
				{
					Debug.Log("set" +  (i+1) + "as" + assignedCntls[i] );
					PlayerPrefs.SetInt("player" + (i+1) + "cntrl",assignedCntls[i]);
				}
				Debug.Log("startgame");
				Application.LoadLevel("testMap");
			}

		}
	}
}
