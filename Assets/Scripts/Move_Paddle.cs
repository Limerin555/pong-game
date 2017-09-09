using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Paddle : MonoBehaviour {

	public float speed = 30;

	void FixedUpdate () {

		float vertInput = Input.GetAxisRaw ("Vertical");

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, vertInput) * speed;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
