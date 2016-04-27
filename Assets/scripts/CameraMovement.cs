using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    // Use this for initialization
    private float speed = 1.5f;
    private float maxSpeed = 3f;
    private float acceleration = 0.2f;
    [HideInInspector]
    public bool moveCamera;
	void Start () {
        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveCamera)
        {
            Move();
        }
	}
    void Move()
    {
        Vector3 tmp = transform.position;
        float oldY = tmp.y;
        float newY = tmp.y - (speed * Time.deltaTime);
       tmp.y = Mathf.Clamp(tmp.y, oldY, newY);
        speed += acceleration * Time.deltaTime;
        transform.position = tmp;
        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
