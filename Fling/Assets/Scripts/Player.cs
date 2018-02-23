using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	float screenWidth;
	float screenHeight;

	bool run = true;
	bool swap = true;

	public Transform[] ghosts = new Transform[2];

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
		for(int i = 0; i < 2; i++)
		{
			ghosts[i] = Instantiate(transform, Vector3.zero, Quaternion.identity) as Transform;
			//ghosts[i].GetComponent<Player>().run = false;
			//ghosts[i].GetComponent<Player>().swap = false;
			ghosts[i].tag = "Ghost" + i;
			Destroy(ghosts [i].GetComponent<Player>());
		}
	}

	void PositionGhostShips()
	{
		var ghostPosition = transform.position;

		//Right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[0].position = ghostPosition;

		// Left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[1].position = ghostPosition;

		// All ghost ships should have the same rotation as the main ship
		for(int i = 0; i < 2; i++)
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
	}
}
