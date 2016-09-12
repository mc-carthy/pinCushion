using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void PlayGame () {
		SceneManager.LoadScene ("main", LoadSceneMode.Single);
	}
}
