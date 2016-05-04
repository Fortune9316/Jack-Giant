using UnityEngine;
using System.Collections;
using CnControls;

public class Player : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D body;
	Animator anim;
	float speed = 8f,maxVelocity = 4f;
    int life;
	void Start () {
		body = GetComponent<Rigidbody2D> ();
        life = GameObject.FindGameObjectsWithTag("life").Length;
	}

	void FixedUpdate(){
		MovePlayer ();
	}

	void MovePlayer(){
		float velocity = Mathf.Abs (body.velocity.x);
		float forceX = 0;
        float h = Input.GetAxisRaw ("Horizontal");
        float y = CnInputManager.GetAxisRaw("Horizontal");
		if (h > 0 || y>0) {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
			if (velocity < maxVelocity) {
				forceX = speed;
			}
		} else if(h<0 || y<0){
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            if (velocity < maxVelocity) {
				forceX = -speed;
			}
		}
		body.AddForce (new Vector2 (forceX, 0));
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Limit")
        {
            gameObject.SetActive(false);
            CameraMovement.instance.moveCamera = false;
            life--;
            GameObject.FindGameObjectWithTag("life").SetActive(false);
        }
    }
    
}
