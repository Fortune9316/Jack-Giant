using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour {

    // Use this for initialization
    float maxX, minX;

	void Start () {
        setBoundsXY();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        if(transform.position.x > maxX)
        {
            position.x = maxX;
        }
        if (transform.position.x < minX)
        {
            position.x = minX;
        }
	}

    void setBoundsXY()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(
                             Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
}
