using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonSnapFunctionality : MonoBehaviour {
    public float rayLength; //this is how far the cam will look for an obj.
    Text overlayCanText;
	// Use this for initialization
	void Start () {
        overlayCanText = GameObject.Find("OverlayCanvas").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //ray logic:
        Vector3 rayStart = transform.position; //start the ray from your pos.
        Vector3 rayDir = transform.TransformDirection(Vector3.forward); //shoot it where you're pointing it
        RaycastHit hitInfo;
        Debug.DrawRay(rayStart, rayDir * rayLength, Color.red);

        Physics.Raycast(rayStart, rayDir, out hitInfo, rayLength);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.gameObject.tag == "SnappableObj")
            {
                SnappableObject snapObj = hitInfo.collider.gameObject.GetComponent<SnappableObject>();
                GameManager.GM.objInCamSights = snapObj.gameObject;
                //Debug.Log("I see a " + snapObj.myName);
                if (!UIManager.UI.dbCurrentlyHighlighted.text.Contains(snapObj.name))
                {
                    UIManager.UI.dbCurrentlyHighlighted.text = "Currently Highlighted: " + snapObj.myName;
                }
                //get the script on the obj and interact with it:
            }
        }else
        {
            if (GameManager.GM.objInCamSights != null) //only do the following once: (otherwise raycasts go wild and fire a ton of times per second... or ~60)
            {
                GameManager.GM.objInCamSights = null;
                UIManager.UI.dbCurrentlyHighlighted.text = "Currently Highlighted: ";
            }

        }
    }
}
