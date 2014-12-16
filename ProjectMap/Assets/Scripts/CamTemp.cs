using UnityEngine;
using System.Collections;

public class CamTemp : MonoBehaviour {

	private GameObject[] players;
	private Vector3 offset;
	public Transform offsetPoint;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		offset = transform.position - offsetPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 center = Vector3.zero;
		int p = 0;
		foreach(GameObject obj in players)
		{
			if(obj)
			{
				p++;
				center += obj.transform.position;
			}
		}
		center = center/p;


		transform.position = center+offset;
	}
}
