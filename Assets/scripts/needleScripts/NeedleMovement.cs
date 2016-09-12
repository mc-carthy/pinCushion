using UnityEngine;
using System.Collections;

public class NeedleMovement : MonoBehaviour {

	[SerializeField]
	private GameObject needleBody;

	private bool canShootNeedle;
	private bool touchedCustion;

	private float speed = 70f;

	private Rigidbody2D rb;

	private void Awake () {
		Initialize ();
	}

	private void Update () {
		if (canShootNeedle) {
			rb.velocity = new Vector2 (0, speed);
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
