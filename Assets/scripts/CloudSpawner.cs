using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    public GameObject[] clouds;
    public float distanceToCloud = 3f;
    float minX;
    float maxX;
    GameObject player;
    float lastPositionY;
	void Start () {
        player = GameObject.Find("Player");
        SetBoundsXY();
        ShuffleClouds();
        SpawnClouds();
        PositionPlayer();
	}

    void SetBoundsXY()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
        
    }
	
    void ShuffleClouds()
    {
        for(int i=0; i < clouds.Length; i++)
        {
            GameObject cloud = clouds[i];
            int random = Random.Range(0, clouds.Length);
            clouds[i] = clouds[random];
            clouds[random] = cloud;
        }
    }

    void SpawnClouds()
    {
        float nextPosition = 0f;
        for (int i = 0; i < clouds.Length; i++)
        {
            float posX = Random.Range(minX, maxX);
            Vector3 tmp = clouds[i].transform.position;
            tmp.x = posX;
            tmp.y = nextPosition;
            lastPositionY = tmp.y;
            nextPosition -= distanceToCloud;
            clouds[i].transform.position = tmp;
        }
    }

    void PositionPlayer()
    {
        GameObject[] dark = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] goods = GameObject.FindGameObjectsWithTag("Cloud");
        for (int i = 0; i < dark.Length; i++)
        {
            if(dark[i].transform.position.y == 0f)
            {
                Vector3 t = dark[i].transform.position;
                dark[i].transform.position = new Vector3(goods[0].transform.position.x, goods[0].transform.position.y, goods[0].transform.position.z);
                goods[0].transform.position = t;
            }
        }
        Vector3 tmp = goods[0].transform.position;
        for(int i = 1; i < goods.Length; i++)
        {
            if(tmp.y < goods[i].transform.position.y)
            {
                tmp = goods[i].transform.position;
            }
        }
        tmp.y += 0.8f;
        player.transform.position = tmp;

    }
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Cloud" || col.gameObject.tag == "Deadly")
        {
            GameObject go = col.gameObject;
            if(go.transform.position.y == lastPositionY)
            {
                ShuffleClouds();
                for(int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        clouds[i].SetActive(true);
                    }
                }
            }
        }

    }
}
