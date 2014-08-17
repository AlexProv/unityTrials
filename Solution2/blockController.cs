using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blockController : MonoBehaviour {
	
	public GameObject type;
	GameObject demo;
	Queue toDestroy;
	
	void Awake()
	{
		toDestroy = new Queue();
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
			demo = null;
			
		}
		//rayPlacer();    
		
		//float lockPos = 0;
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
		//transform.LookAt(new Vector3(transform.position.x,-1,transform.position.z));
	}
	void rayPlacer()
	{
		Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f));
		RaycastHit info; 
		int mask = LayerMask.NameToLayer("block");
		int range = 4;
		
		if(Physics.Raycast(r,out info,range, 1 << mask))
		{
			OnTriggerEnter(info.collider);
		}
		else
		{
			OnTriggerExit();
		}
	}
	
	void delTarget()
	{
        Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f));
        RaycastHit info; 
        int mask = LayerMask.NameToLayer("block");
        int range = 10;
        
        if(Physics.Raycast(r,out info,range, 1 << mask))
        {        
        	Destroy(info.collider.gameObject);
        }
	}
	
	void OnTriggerEnter(Collider other)
	{
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
		
		demo = tn.gameObject;
	}
	
	void OnTriggerExit()
	{   
		toDestroy.Enqueue(demo);
	}
	
	IEnumerator destroying()
	{
		while(true)
		{
			if(toDestroy.Count > 0)
			{
				GameObject g = toDestroy.Dequeue() as GameObject;
				Destroy(g);
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

