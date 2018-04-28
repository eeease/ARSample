using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {
    public GameObject[] objectsToSpawn;
    public List<GameObject> objsOnScreen;
    public Vector3 posToSpawn;
    public GameObject spawnArena;
    public float timer, timerOG;
    public float minHeight, maxHeight; //set the bounds of the 'arena'
    public float circleMod;
    int maxObjsOnScreen = 10;
    int currentObjsOnScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0 && (currentObjsOnScreen<maxObjsOnScreen))
        {
            SpawnAnObject();
            timer = timerOG;
        }


        //remove a random object from the list/screen
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
        }
	}

    void SpawnAnObject()
    {
        Vector2 randPos = Random.insideUnitCircle * circleMod;
        //Debug.Log("randPos = " + randPos);
        float randY = Random.Range(minHeight, maxHeight);
        
        GameObject obj = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], new Vector3(randPos.x, randY, randPos.y), Quaternion.identity) as GameObject;
        objsOnScreen.Add(obj);
        currentObjsOnScreen = objsOnScreen.Count;
        UIManager.UI.dbNumOfObjs.text =  "Number of OBJs on Screen: " +currentObjsOnScreen.ToString();
    }

    public void DestroyObject(GameObject objToDestroy)
    {
        //int randObj = Random.Range(0, objsOnScreen.Count);
        int objIndex = objsOnScreen.IndexOf(objToDestroy);
        Destroy(objsOnScreen[objIndex]);

        objsOnScreen.RemoveAt(objIndex);
        currentObjsOnScreen = objsOnScreen.Count;
        UIManager.UI.dbNumOfObjs.text = "Number of OBJs on Screen: " + currentObjsOnScreen.ToString();

    }
}
