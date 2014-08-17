using UnityEngine;
using System.Collections;

public class NodeFlag : Flag {
	
	public bool isOpen {get;set;} 
	void Awake()
	{ 
		isOpen = true;	
	}
}
