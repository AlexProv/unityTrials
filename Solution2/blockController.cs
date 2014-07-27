using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour {
	
	public GameObject type;
	GameObject demo;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		//float lockPos = 0;
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
		//transform.LookAt(new Vector3(transform.position.x,-1,transform.position.z));
	}
	
	void OnTriggerEnter(Collider other)
	{
		print (other.gameObject.name);
		demo = other.gameObject;
		
		demo = GameObject.Instantiate(type) as GameObject;
		/*
		demo.transform.parent = other.transform;
		
		Transform tn = demo.transform.GetChild(0);
		changeParentChild(demo,tn.gameObject);
		
		tn.transform.parent = other.transform.parent;
		tn.transform.localPosition = Vector3.zero;
		tn.transform.localRotation = Quaternion.identity;
		*/
	}
	
	void OnTriggerExit()
	{
		print("exit " + demo.name);
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
