using UnityEngine;
using System.Collections;

public class NodeFlag : Flag {
	
	public bool Open {get;set;} 
	void Awake()
	{ 
		Open = true;	
	}
}
