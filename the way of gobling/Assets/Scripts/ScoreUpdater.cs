using UnityEngine;
using System.Collections;

public class ScoreUpdater : MonoBehaviour {

	TextMesh score;
	private int points = 0;

	// Use this for initialization
	void Start () {
		score = GameObject.Find ("Score").GetComponent<TextMesh>();
		updateScore ();
	}

	void addPoints(int addedPoints) {
		this.points += addedPoints;
	}

	void updateScore() {
		score.text = points.ToString ();
	}

}
