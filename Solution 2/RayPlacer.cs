using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayPlacer : MonoBehaviour {

	public GameObject Demo;
	public GameObject Type;
	public float range;
	
	private Quaternion q;
	private MeshRenderer m;
	private static bool placeMutex;
	private GameObject buildNode;
	
	private Collider selectedCollider;
	/*
	to be used with a prefab, 
	structure: obj, child with posisiton of collider / node with it's owh child with the collider it self
	*/
	void Awake()
	{
		if(range < 0.1f || range == null)
			range = 3.0f;
		q = Quaternion.identity;
		placeMutex = false;	
		
	}
	// Use this for initialization
	void Start () {
		buildNode = GameObject.Find("BuildNode") as GameObject;
		Demo = GameObject.Instantiate(Demo) as GameObject;
		Demo.transform.parent = this.transform;
		m = Demo.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
		m.enabled = false;
		Demo.transform.parent = buildNode.transform;
		
		foreach(Transform t in Demo.transform)
		{
			foreach(Transform i in t)
			{
				Collider c = i.gameObject.GetComponent(typeof(Collider)) as Collider;
				c.enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		testRay();
		updateQ();

	}
	
	//fail au init les collider reste a off. 
	void testRay()
	{
		Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f));
		RaycastHit info; 
		int mask = LayerMask.NameToLayer("block");
		
		if(Physics.Raycast(r,out info,range, 1 << mask))
		{
			print (info.collider.gameObject.name);
			if(!Demo.transform.parent.Equals(info.collider.transform.parent))// && !placeMutex)
			{
				selectedCollider = info.collider;
				Demo.transform.parent = buildNode.transform;
				Demo.transform.localPosition = Vector3.zero;
				GameObject closest = getNewLocalPosition(info.collider.transform.parent.transform.position);
				
				m.enabled = true;
				Demo.transform.parent = info.collider.transform.parent;
				
				Demo.transform.localPosition = closest.transform.localPosition.magnitude *Vector3.up;
				Demo.transform.localRotation = q;
				placeMutex = true;
			}
			if(Input.GetKeyDown(KeyCode.Mouse0))
			{
				selectedCollider.enabled = false;
				Demo = GameObject.Instantiate(Demo) as GameObject;
				Demo.transform.parent = buildNode.transform;
			}
		}
		else
		{
			Demo.transform.parent = buildNode.transform;
			Demo.transform.localPosition = Vector3.zero;
			m.enabled = false;
			placeMutex = false;
		}
	}
	
	GameObject getNewLocalPosition(Vector3 collidePosition)
	{
		float distance = float.MaxValue;
		GameObject closest = null;
		//Transform [] lt = collidedObj.GetComponentsInChildren(typeof(Transform)) as Transform[]; //is always null
		
		foreach(Transform t in Demo.transform)
		{
			float newDistance = Vector3.Distance(t.position, collidePosition);	
			if(newDistance < distance)
			{
				distance = newDistance;
				closest = t.gameObject;
			}
		}
		//Debug.Log(closest.name);
		return closest;
	}
	
	void updateQ()
	{
		if (Input.GetKey (KeyCode.LeftShift))
		{
			if (Input.GetKeyDown (KeyCode.W)) 
			{
				q*=Quaternion.Euler(new Vector3(90,0,0));
			}
			if (Input.GetKeyDown (KeyCode.S)) 
			{
				q*=Quaternion.Euler(new Vector3(-90,0,0));
			}
			if (Input.GetKeyDown (KeyCode.A)) 
			{
				q*=Quaternion.Euler(new Vector3(0,90,0));
			}
			if (Input.GetKeyDown (KeyCode.D)) 
			{
				q*=Quaternion.Euler(new Vector3(0,-90,0));
			}
			if (Input.GetKeyDown (KeyCode.Q)) 
			{
				q*=Quaternion.Euler(new Vector3(0,0,90));
			}
			if (Input.GetKeyDown (KeyCode.S)) 
			{
				q*=Quaternion.Euler(new Vector3(0,0,-90));
			}
			Demo.transform.localRotation = q;
		}
	}
}
