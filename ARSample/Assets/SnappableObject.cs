using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnappableObject : MonoBehaviour {
    public string myName;
	// Use this for initialization
	void Start () {
        //this isn't built for scalability but it should work for now:
        myName = gameObject.name;

        if (myName.Contains("Apple"))
        {
            myName = "Apple";
        }else if (myName.Contains("Pear"))
        {
            myName = "Pear";
        }else if (myName.Contains("Banana"))
        {
            myName = "Banana";
        }else if (myName.Contains("Orange"))
        {
            myName = "Orange";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
