using UnityEngine;
using System.Collections;

public class BackgroundSpawner : MonoBehaviour {

    // Use this for initialization

    private GameObject[] backgrounds;
    private float lastY;
	void Start () {
        backgrounds = GameObject.FindGameObjectsWithTag("background");
        lastY = backgrounds[0].transform.position.y;
        for(int i=0;i<backgrounds.Length;i++)
        {
            if (lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.transform.position.y == lastY)
        {
            Vector3 tmp = coll.gameObject.transform.position;
            float height = ((BoxCollider2D)coll).size.y;
            for(int i=0;i<backgrounds.Length; i++)
            {
                if (!backgrounds[i].activeInHierarchy)
                {
                    tmp.y -= height;
                    lastY = tmp.y;
                    backgrounds[i].transform.position = tmp;
                    backgrounds[i].SetActive(true);
                }
            }
        }
    }
}
