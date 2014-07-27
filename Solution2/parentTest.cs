using UnityEngine;
using System.Collections;

public class parentTest : MonoBehaviour {
	public GameObject child;
	
	Queue q;
	// Use this for initialization
	void Start () {
		q = new Queue();
		foreach(Transform t in gameObject.transform)
		{
			q.Enqueue(t);
			print(t.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Vector3 pos = child.transform.localPosition;
			Quaternion rot = child.transform.localRotation;
			Transform t = q.Dequeue() as Transform;
			child.transform.parent = t;
			child.transform.localPosition = pos;
			child.transform.localRotation = rot;
			q.Enqueue(t);
		}	
	}
}
