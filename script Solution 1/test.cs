using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class test : MonoBehaviour {
	
	Quaternion q;
	List<Transform> nodes;

	/*
	 * obj target doit etre is trigger
	 * this doit avoir un rigid body
	 * 
	 * */

	void Awake()
	{
		q = Quaternion.identity;
		nodes = new List<Transform> ();
	}
	// Use this for initialization
	void Start () {
		Debug.Log (transform.childCount);
		foreach (Transform t in transform) 
		{
			nodes.Add (t);
			//t.gameObject.AddComponent(typeof(test));
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateQ ();
		this.transform.parent.rotation = q;
	}
	
	void updateQ()
	{
		if (Input.GetKey (KeyCode.LeftShift))
		{
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				q*=Quaternion.Euler(new Vector3(90,0,0));
			}
			if (Input.GetKeyDown (KeyCode.Q)) 
			{
				q*=Quaternion.Euler(new Vector3(-90,0,0));
			}
			if (Input.GetKeyDown (KeyCode.W)) 
			{
				q*=Quaternion.Euler(new Vector3(0,90,0));
			}
			if (Input.GetKeyDown (KeyCode.S)) 
			{
				q*=Quaternion.Euler(new Vector3(0,-90,0));
			}
			if (Input.GetKeyDown (KeyCode.A)) 
			{
				q*=Quaternion.Euler(new Vector3(0,0,90));
			}
			if (Input.GetKeyDown (KeyCode.D)) 
			{
				q*=Quaternion.Euler(new Vector3(0,0,-90));
			}
		}
	}


	void OnCollisionEnter(Collision c)
	{
		//Debug.Log (c.collider.name);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("me " + this.name + " other " + other.name);
		//Debug.Log (c.gameObject.name);
		//Debug.Log (c.transform.name);
	}
	
	
}