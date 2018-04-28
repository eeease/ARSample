using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager GM;

    public string[] objsToHuntFor;

    public string currentOBJTarget;
    public GameObject objInCamSights;

    public int score = 0;
    public SpawnObjects spawner;

    void Awake()
    {
        GM = this;
    }
	// Use this for initialization
	void Start () {
        PickANewTarget();
        spawner = GameObject.Find("ObjectSpawner").GetComponent<SpawnObjects>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompareAndScore();
        }
		
	}

    public void PickANewTarget()
    {
        currentOBJTarget = objsToHuntFor[Random.Range(0,objsToHuntFor.Length)];
        UIManager.UI.currentTarget.text = "Snap This!\n" + currentOBJTarget;
    }

    public void CompareAndScore()
    {
        if (objInCamSights != null)
        {
            if (objInCamSights.name.Contains(currentOBJTarget))
            {
                ScoreUpdate(true);
            }
            else if(objInCamSights.name.Contains("Sphere") || objInCamSights.name.Contains("Cube"))
            {
                //do nothing
            }else
            {
                ScoreUpdate(false);
            }
            spawner.DestroyObject(objInCamSights);
            UIManager.UI.dbCurrentlyHighlighted.text = "Currently Highlighted: ";

            objInCamSights = null; //get rid of what was just scored 

        }
    }

    public void ScoreUpdate(bool upOrFalse)
    {
        if (upOrFalse)
        {
            score++;
            AudioManager.AM.PlayClip(0);
        }else
        {
            score--;
            AudioManager.AM.PlayClip(1);

        }
        UIManager.UI.dbScore.text = "Score: " + score.ToString();
        PickANewTarget();
    }
}
