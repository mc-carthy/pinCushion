using UnityEngine;
using System.Collections;

public class CushionRotation : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 100f;

	private bool canRotate;
	private float angle;

	private void Awake () {
		canRotate = true;
		ChangeRotationSpeed ();
	}

	private void Update () {
		if (canRotate) {
			RotateCushion ();
		}
	}

	private void RotateCushion () {
		angle = transform.rotation.eulerAngles.z;
		angle += rotationSpeed * Time.deltaTime;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}

	private IEnumerator ChangeRotationSpeed () {
		yield return new WaitForSeconds(Random.Range(2, 5));
		rotationSpeed = Random.Range (75, 250);
		ChangeRotationSpeed ();
	}
}