using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager UI;

    public Canvas myCan;
    public GameObject debugPanel;
    public Text dbCurrentlyHighlighted, dbScore, dbNumOfObjs, currentTarget;

    void Awake()
    {
        UI = this;
    }
	// Use this for initialization
	void Start () {
        myCan = GetComponent<Canvas>();
        debugPanel = GameObject.Find("DebugPanel");
        foreach(Text txt in debugPanel.GetComponentsInChildren<Text>())
        {
            if (txt.name.Contains("Objs"))
            {
                dbNumOfObjs = txt;
            }
            if (txt.name.Contains("Score"))
            {
                dbScore = txt;
            }
            if (txt.name.Contains("Highlighted"))
            {
                dbCurrentlyHighlighted = txt;
            }
        }
        currentTarget = GetComponentInChildren<Text>(); //this is a bit lazy and probably not 100% but should work for now.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchDebugPanel()
    {
        if (debugPanel.activeSelf)
        {
            debugPanel.SetActive(false);
        }
        else
        {
            debugPanel.SetActive(true);
        }
    }
}
