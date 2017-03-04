using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	private GameObject scoreText;
	private int score = 0;
	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("ScoreText");
		this.scoreText.GetComponent<Text> ().text = "Score: "+score;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag("SmallStarTag")) {
			score += 10;
		} else if (other.gameObject.CompareTag("LargeStarTag")) {
			score += 30;
		} else if (other.gameObject.CompareTag("SmallCloudTag") || other.gameObject.CompareTag("SmallCloudTag")) {
			score +=20;
		}
		this.scoreText.GetComponent<Text> ().text = "Score: "+score;
	}
}
