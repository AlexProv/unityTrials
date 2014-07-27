using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrolScript : MonoBehaviour {
	
	public GameObject[] waypoints;
	public int startIndex; 
	private int index; 
	
	void Awake()
	{
	
	}
	
	private GameObject nextCircular()
	{
		if(index > waypoints.Length)
		{
			index = 0;
			return waypoints[index];	
		}
		else
		{
			GameObject i = waypoints[index];
			index++;
			return i;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
