using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	private float visiblePosZ = -6.5f;

	private GameObject gameoverText;

	private GameObject scoreText;

	private int score;

	// Use this for initialization
	void Start () {
		this.gameoverText = GameObject.Find("GameOverText");	
		this.scoreText    = GameObject.Find("ScoreText");	
		this.score        = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.z < this.visiblePosZ) {
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}

		this.scoreText.GetComponent<Text>().text = "Score:" + score;
	}

	void OnCollisionEnter(Collision other) {
		// Debug.Log(other.collider.tag);

		tag = other.collider.tag;
		
		if (tag == "SmallStarTag") {
			this.score += 10;
		}

		if (tag == "LargeStarTag") {
			this.score += 20;
		}

		if (tag == "SmallCloudTag") {
			this.score += 30;
		}

		if (tag == "LargeCloudTag") {
			this.score += 40;
		}
	}
}
