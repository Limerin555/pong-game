using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue_playing_music : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (gameObject);
    }
}
