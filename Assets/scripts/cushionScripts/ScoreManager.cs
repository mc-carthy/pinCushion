using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	private Text scoreText;
	private int score;

	private void Awake () {
		MakeInstance ();
		scoreText = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<Text> ();
		scoreText.text = score.ToString ();
	}

	public void SetScore () {
		score++;
		scoreText.text = score.ToString ();
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}
}
