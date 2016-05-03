using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	// Use this for initialization
	public int flag;
	void Start () {
		flag = 0;
	}
    public void OnPointerDown(PointerEventData data)
    {
        print(gameObject.name + "Was down");
			flag = 1;
		
    }
    public void OnPointerUp(PointerEventData data)
    {
        print(gameObject.name + "Was up");
		flag = 0;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
