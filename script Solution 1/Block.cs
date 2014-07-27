using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	public void Place (){
	}

	void Awake()
	{
	}
	
	void Start () {
	}

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

	void OnTriggerEnter(Collider c)
	{
		Debug.Log ("on trigger enter");
	}
	
	void OnTriggerExit()
	{
		Debug.Log ("on trigger exit");
	}

	void nextNode()
	{
	}
}
