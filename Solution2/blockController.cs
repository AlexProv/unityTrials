using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blockController : MonoBehaviour {
	
	public GameObject type;
	GameObject demo;
	Queue toDestroy;
	public GUIText textAlarm;
	
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
		//float lockPos = 0;
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
		//transform.LookAt(new Vector3(transform.position.x,-1,transform.position.z));
	}
	
	void OnTriggerEnter(Collider other)
	{
		textAlarm.text = other.name;
		print (other.gameObject.name);
		demo = other.gameObject;
		
		demo = GameObject.Instantiate(type) as GameObject;
		demo.transform.parent = other.transform;
		
		Transform tn = demo.transform.GetChild(0);
		changeParentChild(demo,tn.gameObject);
		
		tn.transform.parent = other.transform;
		tn.transform.localPosition = Vector3.zero;
		tn.transform.localRotation = Quaternion.identity;
		
		demo = tn.gameObject;
		demo.transform.localRotation = Quaternion.Euler(new Vector3(-90,0,0));
	}
	
	void OnTriggerExit()
	{	
		textAlarm.text = "";
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
