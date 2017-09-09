using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public float speed = 30;

	private Rigidbody2D rigidBody;

	private AudioSource audioSource;



	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.velocity = Vector2.right * speed;

	}

	void OnCollisionEnter2D(Collision2D col){

		// Hits Left_paddle or Right_paddle

		if ((col.gameObject.name == "Left_paddle") || (col.gameObject.name == "Right_paddle")) {

			HandlePaddleHit (col);

		}


		// Hits Top_wall or Bottom_wall

		if ((col.gameObject.name == "Bottom_wall") || (col.gameObject.name == "Top_wall")) {
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.wallBloop);
		}

		// Hits Left_goal or Right_goal

		if ((col.gameObject.name == "Left_goal") || (col.gameObject.name == "Right_goal")) {
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.goalBloop);

			// Update goal score UI
			if (col.gameObject.name == "Left_goal") 
			{
				IncreaseTextUIScore ("RightScoreUI");
			} 

			if (col.gameObject.name == "Right_goal") 
			{
				IncreaseTextUIScore ("LeftScoreUI");
			}

			transform.position = new Vector2 (0, 0);
		}
	}

	void HandlePaddleHit (Collision2D col)
		{
		float y = BallHitPaddleWhere(transform.position, col.transform.position, col.collider.bounds.size.y);

			Vector2 dir = new Vector2();

			if (col.gameObject.name == "Left_paddle")
			{
				dir =  new Vector2(1, y).normalized;
			}

			if (col.gameObject.name == "Right_paddle")
			{
				dir = new Vector2(-1, y).normalized;
			}

			rigidBody.velocity = dir * speed;

			SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
		}

		float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
		{
		return (ball.y - paddle.y) / paddleHeight;
		}

	void IncreaseTextUIScore(string textUIName)
	{
		var textUIComp = GameObject.Find (textUIName).GetComponent <Text>();

		int score = int.Parse (textUIComp.text);

		score++;

		textUIComp.text = score.ToString ();
	}
}
