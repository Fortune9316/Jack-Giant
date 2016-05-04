using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {


	public Button startGame,highScore,options,quit;
	void Start () {
		startGame.onClick.AddListener (() => goGame ());
		highScore.onClick.AddListener (() => goHighScore ());
		options.onClick.AddListener (() => goOptions ());
		quit.onClick.AddListener (() => goQuit ());
	}

	void goGame(){
		FacebookController.instance.login ();
	}

	void goHighScore(){
		SceneManager.LoadScene ("HighScore");
	}

	void goOptions(){
		SceneManager.LoadScene ("Options");
	}

	void goQuit(){
		Application.Quit ();
	}
}
