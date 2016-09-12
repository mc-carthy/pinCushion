using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[SerializeField]
	private GameObject needle;
	[SerializeField]
	private int needleCount;
	[SerializeField]
	private GameObject cushion;
	[SerializeField]
	private GameObject prepinnedNeedle;
	[SerializeField]
	private int prepinnedNeedleCount;

	private Button shootBtn;
	private GameObject[] needles;
	private float needleDistance = 0.8f;
	private float shiftSpeed = 0.5f;
	private float cushionRadius;
	private float needleInsertionDepth = 0.1f;
	private float prepinnedNeedleDistance;
	private int needleIndex;
	private int instantiatedNeedles;
	private bool shiftNeedles;

	private void Awake () {
		MakeInstance ();
		GetButton ();
		cushionRadius = cushion.GetComponent<CircleCollider2D> ().radius;
		prepinnedNeedleDistance = 3;//= cushionRadius - needleInsertionDepth;
	}

	private void Start () {
		needles = new GameObject[needleCount];
		Vector3 temp = transform.position;

		for (int i = 0; i < needles.Length; i++) {
			needles[i] = Instantiate (needle, temp, Quaternion.identity) as GameObject;
			temp.y -= needleDistance;
		}
		InstantiatePrepinnedNeedles ();
	}


	public void ShootNeedle () {
		needles [needleIndex].GetComponent<NeedleMovement> ().FireNeedle ();
		needleIndex++;

		if (needleIndex == needles.Length + instantiatedNeedles) {
			Debug.Log ("No more needles");
			shootBtn.onClick.RemoveAllListeners ();
		}
	}

	public void ShiftNeedles () {
		for (int i = 0; i < needles.Length; i++) {
			if (!needles [i].GetComponent<NeedleMovement> ().touchedCushion) {
				Vector3 temp = needles [i].transform.position;
				temp.y += needleDistance;
				needles [i].transform.position = temp;
			}
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

	private void InstantiatePrepinnedNeedles () {
		for (int i = 0; i < prepinnedNeedleCount; i++) {
			GameObject newNeedle = Instantiate (prepinnedNeedle, cushion.transform.position + Vector3.down * prepinnedNeedleDistance, Quaternion.identity) as GameObject;
			newNeedle.transform.RotateAround(cushion.transform.position, Vector3.forward, Random.Range(0, 360));
			newNeedle.transform.SetParent (cushion.transform);
		}
	}
}
