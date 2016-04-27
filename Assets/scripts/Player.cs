using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D body;
    Animator animator;
    float speed = 5f;
    float maxVelocity = 4f;
    float forceX = 0;
	void Start () {
        body = GetComponent<Rigidbody2D>();
        
	}

    void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        float velocity = Mathf.Abs(body.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if(velocity < maxVelocity)
            {
                forceX = speed;
            }
        }else if(h<0)
        {
            if(velocity < maxVelocity)
            {
                forceX = -speed;
            }
        }
        body.AddForce(new Vector2(forceX, 0));
    }

    // Update is called once per frame
    void Update () {
	
	}
}
