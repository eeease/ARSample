using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour {
    public bool rotateX, rotateY, rotateZ;
    public float currentRotateSpeed, rotateSpeed, rotateSpeedMax;
    public bool rotateSeparately;
    public float timeToStoreRot, timeToStoreRotMax; //for some reason the objects are stalling at a certain rotation.  with this, i can check what the rotation was a second or two ago and if it's the same as it is now (it hasn't moved), then i can push it along and restart the rotating.
    Vector3 previousRot;
    // Use this for initialization
	void Start () {
        rotateSpeed = Random.Range(-rotateSpeedMax, rotateSpeedMax); //just set this once so you can go back to it if you have to.
        currentRotateSpeed = rotateSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotateX)
        {
            transform.Rotate(new Vector3(transform.localRotation.x + currentRotateSpeed, 0, 0));
        }




        StallLogic();
		
	}

    void StallLogic()
    {

        timeToStoreRot -= Time.deltaTime;
        if (timeToStoreRot <= 0)
        {
            previousRot = transform.localRotation.eulerAngles;
            if(previousRot == transform.localRotation.eulerAngles)
            {
                currentRotateSpeed = rotateSpeedMax;
            }else
            {
                currentRotateSpeed = rotateSpeed;
            }
            timeToStoreRot = timeToStoreRotMax;
        }
    }
}
