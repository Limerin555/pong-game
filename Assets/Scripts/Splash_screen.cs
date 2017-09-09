using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_screen : MonoBehaviour {

	public string sceneToLoad;

	public int secsTillSceneLoad;


	// Use this for initialization
	void Start () {

		Invoke("OpenNextScene", secsTillSceneLoad);
		
	}

	void OpenNextScene() 
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
