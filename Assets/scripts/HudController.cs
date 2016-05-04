using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject ready;
    private Button readyBtn;
    public static HudController instance;

    void Awake()
    {
        instance = this;
    }
	void Start () {
        Time.timeScale = 0;
        readyBtn = ready.GetComponent<Button>();
        readyBtn.onClick.AddListener(() => startGame());
	}
	
	// Update is called once per frame
	void startGame () {
        readyBtn.onClick.RemoveAllListeners();
        ready.SetActive(false);
        Time.timeScale = 1;
	}
}
