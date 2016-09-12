using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[SerializeField]
	private GameObject needle;
	[SerializeField]
	private int needleCount;

	private Button shootBtn;
	private GameObject[] needles;
	private float needleDistance = 0.8f;
	private int needleIndex;
	private int instantiatedNeedles;

	private void Awake () {
		MakeInstance ();
		GetButton ();
	}

	private void Start () {
		needles = new GameObject[needleCount];
		Vector3 temp = transform.position;

		for (int i = 0; i < needles.Length; i++) {
			needles[i] = Instantiate (needle, temp, Quaternion.identity) as GameObject;
			temp.y -= needleDistance;
		}
	}

	public void ShootNeedle () {
		needles [needleIndex].GetComponent<NeedleMovement> ().FireNeedle ();
		needleIndex++;

		if (needleIndex == needles.Length + instantiatedNeedles) {
			Debug.Log ("No more needles");
			shootBtn.onClick.RemoveAllListeners ();
		}
	}

	public void InstantiateNeedle () {
		Instantiate (needle, transform.position, Quaternion.identity);
		instantiatedNeedles++;
	}

	private void MakeInstance () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	private void GetButton () {
		shootBtn = GameObject.FindGameObjectWithTag ("shootBtn").GetComponent<Button> ();
		shootBtn.onClick.RemoveAllListeners ();
		shootBtn.onClick.AddListener (() => ShootNeedle ());
	}

	private void CreateNeedles () {

	}
}
