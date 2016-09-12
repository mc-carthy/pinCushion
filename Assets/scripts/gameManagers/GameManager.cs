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
	private float needleDistance = 1.5f;
	private int needleIndex;

	private void Awake () {

	}
}
