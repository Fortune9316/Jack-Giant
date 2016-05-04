using UnityEngine;
using System.Collections;

public class BgScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float heightWorld = Camera.main.orthographicSize * 2f;

        float widthWorld = heightWorld / Screen.height * Screen.width;

        float width = GetComponent<BoxCollider2D>().size.x;

        Vector3 tmp = transform.localScale;

        tmp.x = widthWorld / width;

        transform.localScale = tmp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
