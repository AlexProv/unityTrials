﻿using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour {
	
	public GameObject type;
	GameObject demo;
	
	public GameObject a;
	public GameObject b;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		//float lockPos = 0;
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
		//transform.LookAt(new Vector3(transform.position.x,-1,transform.position.z));
		
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			changeParentChild(a,b);
			
			GameObject c = b;
			b = a;
			a = c;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		print (other.gameObject.name);
		demo = GameObject.Instantiate(type) as GameObject;
		demo.transform.parent = other.transform;
		
	}
	
	void OnTriggerExit()
	{
		Destroy(demo);
	}
	
	void changeParentChild(GameObject parent, GameObject child)
	{
		Transform parentParent = null;
		if(!parent.transform.parent == null)
			parentParent = parent.transform.parent;
		child.transform.parent = null;
		child.transform.parent = parentParent;
		
		
		parent.transform.parent = null;
		parent.transform.parent = child.transform;
		
		print(parent);
		print (child);
	}
}


/*

		Quaternion rot = child.transform.localRotation;
		Transform t = q.Dequeue() as Transform;
		child.transform.parent = t;
		child.transform.localPosition = pos;
		child.transform.localRotation = rot;
*/
