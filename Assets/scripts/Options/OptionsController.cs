using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	[SerializeField]
	private Button easy,medium, hard, back;
	[SerializeField]
	private GameObject check;
	[SerializeField]
	private Transform easyPos,mediumPos,hardPos;

	void Start () {
		easy.onClick.AddListener (() => startEasy ());
		medium.onClick.AddListener (() => startMedium ());
		hard.onClick.AddListener (() => startHard ());
		back.onClick.AddListener (() => goBack ());
		check.SetActive (false);
	}
	
	void startEasy(){
		check.SetActive (true);
		check.transform.position = easyPos.position;
	}

	void startMedium(){
		check.SetActive (true);
		check.transform.position = mediumPos.position;
	}

	void startHard(){
		check.SetActive (true);
		check.transform.position = hardPos.position;
	}

	void goBack(){
		SceneManager.LoadScene ("Menu");
	}
}
