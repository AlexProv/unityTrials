using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	// Use this for initialization
	TestBlock blockScript;

	void Start () {
		blockScript = transform.parent.gameObject.GetComponent (typeof(TestBlock)) as TestBlock;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision c)
	{
		Debug.Log ("on collision enter");
	}
	
	void OnCollisionExit()
	{
		Debug.Log ("on collision enter");
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		if (!blockScript.useMutex) 
		{
			//Debug.Log ("on trigger enter");
			Debug.Log (other.gameObject.name);
			MeshRenderer m = transform.parent.gameObject.GetComponent (typeof(MeshRenderer)) as MeshRenderer;
			m.enabled = false;

			foreach (Transform t in transform.parent) {
					m = t.gameObject.GetComponent (typeof(MeshRenderer)) as MeshRenderer;
					m.enabled = false;
			}

			blockScript.Demo.transform.parent = other.transform;
			blockScript.Demo.transform.localPosition = transform.localPosition;
			blockScript.Demo.transform.localRotation = transform.localRotation;
			blockScript.demoMesh.enabled = true;
		}

	}
	

	
	void OnTriggerExit()
	{
		if (blockScript.useMutex)
		{
			Debug.Log ("on trigger exit");

			MeshRenderer m = transform.parent.gameObject.GetComponent (typeof(MeshRenderer)) as MeshRenderer;
			m.enabled = false;

			foreach (Transform t in transform.parent) {
					m = t.gameObject.GetComponent (typeof(MeshRenderer)) as MeshRenderer;
					m.enabled = true;
			}
			//delete + flag
			blockScript.demoMesh.enabled = false;
			blockScript.useMutex = false;

		}
	}
}
