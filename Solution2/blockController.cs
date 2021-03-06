﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blockController : MonoBehaviour {
	
	public GameObject type;
	GameObject demo;
	Queue toDestroy;
	Queue toEnable;
	
	void Awake()
	{
		toDestroy = new Queue();
		toEnable = new Queue();
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(destroying());
	}
	
	// Update is called once per frame
	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			demo.transform.parent.gameObject.collider.enabled = false;
			demo.layer = LayerMask.NameToLayer("blockInterior");
			demo = null;
		}
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			delTarget();
		}
		else
		{
			rayPlacer();
		}
		
	}
	void rayPlacer()
	{
		Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f));
		RaycastHit info; 
		int mask = LayerMask.NameToLayer("block");
		int range = 4;
		
		if(Physics.Raycast(r,out info,range, 1 << mask))
		{
			NodeFlag nf = info.collider.gameObject.GetComponent(typeof(NodeFlag)) as NodeFlag;
			if(nf.isOpen)
			{
				nf.isOpen = false;
				OnEnter(info.collider);
			}
		}
		else
		{
			if(demo != null)
				OnExit();
		}
	}
	
	void delTarget()
	{
        Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f));
        RaycastHit info; 
		int mask = LayerMask.NameToLayer("blockInterior");
        int range = 10;
        if(Physics.Raycast(r,out info,range, 1 << mask))
        {  
        	print(info.collider.name);     
			//NodeFlag nf = info.collider.gameObject.GetComponent(typeof(NodeFlag)) as NodeFlag;
			//nf.isOpen = true;
			toDestroy.Enqueue(info.collider.gameObject);
        	//Destroy(info.collider.gameObject);
        }
	}
	
	void OnEnter(Collider other)
	{
		if(demo != null)
		{
			toDestroy.Enqueue(demo);
			destroying();
		}
		
		demo = other.gameObject;
		
		demo = GameObject.Instantiate(type) as GameObject;
		demo.transform.parent = other.transform;
		
		Transform tn = demo.transform.GetChild(0);
		changeParentChild(demo,tn.gameObject);
		
		tn.transform.parent = other.transform;
		tn.transform.localPosition = Vector3.zero;
		tn.transform.localRotation = Quaternion.Euler(new Vector3(-90,0,0));
		
		demo = tn.gameObject;	
	}
	
	void OnExit()
	{	
		//GameObject g = demo.transform.parent.gameObject;
		//(demo.transform.parent.gameObject.GetComponent(typeof(NodeFlag)) as NodeFlag).isOpen = true;
		//toEnable.Enqueue(demo.transform.parent.gameObject);
		toDestroy.Enqueue(demo);
	}
	
	
	void OnTriggerEnter(Collider other)
	{
	/*
		print(other.gameObject.name);
		if(demo != null)
		{
			toDestroy.Enqueue(demo);
			destroying();
		}
		
		demo = other.gameObject;
		
		demo = GameObject.Instantiate(type) as GameObject;
		demo.transform.parent = other.transform;
		
		Transform tn = demo.transform.GetChild(0);
		changeParentChild(demo,tn.gameObject);
		
		tn.transform.parent = other.transform;
		tn.transform.localPosition = Vector3.zero;
		tn.transform.localRotation = Quaternion.Euler(new Vector3(-90,0,0));
		
		demo = tn.gameObject;*/
	}

	void OnTriggerExit()
	{   
	/*
		NodeFlag nf = demo.transform.parent.gameObject.GetComponent(typeof(NodeFlag)) as NodeFlag;
		nf.isOpen = true;
		toDestroy.Enqueue(demo);
		*/
	}
	
	IEnumerator destroying()
	{
		while(true)
		{
			if(toDestroy.Count > 0)
			{
				GameObject g = toDestroy.Dequeue() as GameObject;
				(g.transform.parent.gameObject.GetComponent(typeof(NodeFlag)) as NodeFlag).isOpen = true;
				g.transform.parent.gameObject.collider.enabled = true;
				g.transform.parent.gameObject.layer = LayerMask.NameToLayer("block");
				DestroyImmediate(g);
			}
			else
			{
				yield return null;
			}
		}   
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
	}
}

