using UnityEngine;
using System.Collections;

public class SunScript : MonoBehaviour {
	public int rayon;
	private int angle;
	private float stamp;
	public float deltaInc;
	private int i;

	void Awake()
	{
		angle = 0;

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - stamp > deltaInc){
			stamp = Time.time;
			i++;

			float x = Mathf.Cos(Mathf.Deg2Rad * i); 
			float y = Mathf.Sin(Mathf.Deg2Rad * i);

			Vector3 temp = new Vector3(0,y,x);
			temp*=rayon;

			this.gameObject.transform.position = temp;
			this.gameObject.transform.LookAt(Vector3.zero);
		}
	}
}
