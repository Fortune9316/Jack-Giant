using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	public Button backButton;
	// Use this for initialization
	void Start () {
		backButton.onClick.AddListener(()=>back());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void back(){
		SceneManager.LoadScene("Menu");
	}
}
