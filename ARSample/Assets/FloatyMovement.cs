using UnityEngine;
using System.Collections;

public class FloatyMovement : MonoBehaviour {
    public float period, rangeY, rangeX, rangeZ;
    public float currentRange, maxRandRange;
    private Vector3 originalPos;

    [Header("")]
    public bool switchRangesOnTimer;
    public float timeToSwitch, timeToSwitchMax;
    public float lerpSpeed;

	// Use this for initialization
	void Start () {
        originalPos = transform.localPosition;
        currentRange = Random.Range(0, maxRandRange);
	}
	
	// Update is called once per frame
	void Update () {
        if (switchRangesOnTimer)
        {
            timeToSwitch -= Time.deltaTime;
            if (timeToSwitch <= 0)
            {
                currentRange = Random.Range(0, maxRandRange);
                timeToSwitch = timeToSwitchMax;
            }
        }
        Vector3 offset = Vector3.zero;

        offset.x = Mathf.Sin(Time.time * period) * (rangeX+maxRandRange);
        offset.y = Mathf.Sin(Time.time * period) * (rangeY+maxRandRange);
        offset.z = Mathf.Sin(Time.time * period) * (rangeZ+maxRandRange);

        transform.localPosition = originalPos + offset;

        period = Mathf.Lerp(period, currentRange, Time.deltaTime*lerpSpeed);

    }
}
