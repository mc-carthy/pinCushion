using UnityEngine;
using System.Collections;

public class NeedleHead : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D trig) {
		if (trig.gameObject.tag == "needleHead") {
			Debug.Log ("Game Over");
			Time.timeScale = 0;
		}
	}
}
