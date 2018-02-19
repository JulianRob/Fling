using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float speed = .05f;
	float screenWidth;
	float screenHeight;

	bool run = true;
	bool swap = true;

	public Transform[] ghosts = new Transform[8];

	void Start()
	{
		var cam = Camera.main;

		var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
		var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

		screenWidth = screenTopRight.x - screenBottomLeft.x;
		screenHeight = screenTopRight.y - screenBottomLeft.y;
	}


	void CreateGhostShips()
	{
		for(int i = 0; i < 8; i++)
		{
			ghosts[i] = Instantiate(transform, Vector3.zero, Quaternion.identity) as Transform;
			ghosts[i].GetComponent<Player>().run = false;
			ghosts[i].GetComponent<Player>().swap = false;
			ghosts[i].tag = "Ghost" + i;
			//Destroy (ghosts [i].GetComponent<Ball>());
			//Destroy (ghosts [i].GetComponent<SpringJoint2D>());
			Destroy (ghosts [i].GetComponent<Player>());
			//Destroy (ghosts [i].GetComponent<Rigidbody2D>());
		}
	}

	void PositionGhostShips()
	{
		// All ghost positions will be relative to the ships (this) transform,
		// so let's star with that.
		var ghostPosition = transform.position;

		// We're positioning the ghosts clockwise behind the edges of the screen.
		// Let's start with the far right.
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[0].position = ghostPosition;

		// Bottom-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[1].position = ghostPosition;

		// Bottom
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[2].position = ghostPosition;

		// Bottom-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[3].position = ghostPosition;

		// Left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[4].position = ghostPosition;

		// Top-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[5].position = ghostPosition;

		// Top
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[6].position = ghostPosition;

		// Top-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[7].position = ghostPosition;

		// All ghost ships should have the same rotation as the main ship
		for(int i = 0; i < 8; i++)
		{
			ghosts[i].rotation = transform.rotation;
		}
	}

	void SwapShips()
	{
		foreach(var ghost in ghosts)
		{
			if (ghost.position.x < screenWidth && ghost.position.x > -screenWidth &&
				ghost.position.y < screenHeight && ghost.position.y > -screenHeight)
			{
				transform.position = ghost.position;

				break;
			}
		}

		PositionGhostShips();
	}

	void FixedUpdate() 
	{
		if (run == true && GameObject.Find("Ball").GetComponent<Ball>().stop == true)
		{
			CreateGhostShips ();
			PositionGhostShips ();
			foreach(var ghost in ghosts)
			{
				ghost.GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
				ghost.GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;
			}
			run = false;
		}

		if (swap == true && GameObject.Find("Ball").GetComponent<Ball>().stop == true)
		{
			SwapShips ();
		}

		if (Input.GetKey ("w")) 
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y+speed, transform.position.z);
		}

		if (Input.GetKey ("a")) 
		{
			transform.position = new Vector3 (transform.position.x-speed, transform.position.y, transform.position.z);
		}

		if (Input.GetKey ("s")) 
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y-speed, transform.position.z);
		}

		if (Input.GetKey ("d")) 
		{
			transform.position = new Vector3 (transform.position.x+speed, transform.position.y, transform.position.z);
		}
	}
}
