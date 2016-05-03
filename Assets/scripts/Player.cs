using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D body;
    Animator animator;
    float speed = 5f;
    float maxVelocity = 4f;
    float forceX = 0;

	public GameObject buttonLeft;
	public GameObject buttonRight;
	Click clickScriptleft;
	Click clickScriptRight;

	private int flagRight;
	private int flagLeft;
	void Start () {
        body = GetComponent<Rigidbody2D>();

		clickScriptleft = buttonLeft.GetComponent<Click>();
		clickScriptRight = buttonRight.GetComponent<Click>();
	}

    void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        float velocity = Mathf.Abs(body.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0  || flagRight==1)
        {
            if(velocity < maxVelocity)
            {
                forceX = speed;
            }
		}else if(h<0 || flagLeft==1)
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
		flagRight = clickScriptRight.flag;
		flagLeft = clickScriptleft.flag;
	}
}
