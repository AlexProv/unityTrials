using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

	enum flag_value {tst, ts}
	void Awake()
	{
		print(flag_value.ts);
	}
	
	public string value{ get; private set;}
	
	public void setFlag()
	{
	
	}
	
}
