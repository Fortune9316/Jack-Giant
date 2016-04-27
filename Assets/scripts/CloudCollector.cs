using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

    // Use this for initialization

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Cloud" || col.gameObject.tag == "Deadly")
        {
            col.gameObject.SetActive(false);
        }
    }
 }
