using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager AM;
    public AudioSource aSource;
    public AudioClip[] aClips;
    void Awake()
    {
        AM = this;
    }
	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayClip(int whichClip)
    {
        aSource.clip = aClips[whichClip];
        aSource.Play();
    }
}
