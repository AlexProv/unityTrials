using UnityEngine;
using System.Collections;

public class TestBlock : MonoBehaviour {

	private Quaternion q;
	public bool useMutex;
	public GameObject Demo;
	public MeshRenderer demoMesh;
	
	// Use this for initialization
	void Awake()
	{
		q = Quaternion.identity;
		useMutex = false;
		Demo = GameObject.Instantiate(Demo) as GameObject;
		demoMesh = Demo.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
		demoMesh.enabled = false;
		
		//hack
		foreach(Transform t in Demo.transform)
		{
			MeshRenderer m = t.gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
			m.enabled = false;
		}
			
		
	}
	void Start () {
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
		}
	}
	// Update is called once per frame
	void Update () {
		updateQ ();
		//Debug.Log (transform.forward.ToString ());
		transform.localRotation = q;
	}
}
