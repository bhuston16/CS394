using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVelocity;
    bool didFlap = false;
    public float maxSpeed = 5f;
    
	// Use this for initialization
	void Start () {
	
	}

    //Do graphic and input updates
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //on a mobile device, getmousebuttondown(0) is a tap on the screen
        {
            didFlap = true;
        }
    }

	// Update is called once per frame
    //Do physics engine updates here
	void FixedUpdate () {
        velocity += gravity * Time.deltaTime; //amount of distance moved in one second

        if (didFlap)
        {
            didFlap = false;
            velocity += flapVelocity;
            
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed); //ClampMagnitude keeps a range between argument 1 and 2, in this case velocity and maxSpeed

        transform.position += velocity * Time.deltaTime; //keep track of time for proper update

        float angle = 0;
        if (velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -90, velocity.y / maxSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
