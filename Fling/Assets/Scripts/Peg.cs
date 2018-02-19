using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour {

	int ghostNumber = 0;

	// Update is called once per frame
	void FixedUpdate () 
	{
		//transform.position = new Vector3(transform.position.x,transform.position.y-0.1f,transform.position.z);
		if (transform.position.y <= -7f) 
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ball") 
		{
			ghostNumber = 8;
		}

		for(int i = 0; i < 8; i++)
		{
			if (col.gameObject.tag == "Ghost" + i) 
			{
				ghostNumber = i;
				break;
			}
		}

		if (ghostNumber <= 7 && col.gameObject.tag == "Ghost" + ghostNumber) 
		{
			GameObject.FindGameObjectWithTag ("Ghost" + 0).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 0).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag ("Ghost" + 1).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 1).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag ("Ghost" + 2).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 2).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag ("Ghost" + 3).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 3).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag ("Ghost" + 4).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 4).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag ("Ghost" + 5).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 5).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag ("Ghost" + 6).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 6).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag ("Ghost" + 7).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 7).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;
		}
		else 
		{
			GameObject.FindGameObjectWithTag("Ghost" + 0).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 0).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag("Ghost" + 1).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 1).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag("Ghost" + 2).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 2).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag("Ghost" + 3).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 3).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag("Ghost" + 4).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 4).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag("Ghost" + 5).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 5).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag("Ghost" + 6).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 6).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag("Ghost" + 7).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 7).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;
		}
	}
}
