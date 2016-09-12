using UnityEngine;
using System.Collections;

public class NeedleMovement : MonoBehaviour {

	[SerializeField]
	private GameObject needleBody;

	private bool canShootNeedle;
	private bool touchedCushion;

	private float speed = 5f;

	private Rigidbody2D rb;

	private void Awake () {
		Initialize ();
		FireNeedle ();
	}

	private void Update () {
		if (canShootNeedle) {
			rb.velocity = new Vector2 (0, speed);
		}
	}

	private void OnTriggerEnter2D (Collider2D trig) {
		if (!touchedCushion) {
			if (trig.tag == "cushion") {
				canShootNeedle = false;
				touchedCushion = true;
				rb.isKinematic = true;
			}
		}
	}

	public void FireNeedle () {
		needleBody.SetActive (true);
		rb.isKinematic = false;
		canShootNeedle = true;
	}

	private void Initialize () {
		needleBody.SetActive (false);
		rb = GetComponent<Rigidbody2D> ();
	}
}
