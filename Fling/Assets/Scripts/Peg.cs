using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour {

	int ghostNumber = 10;

	Hook hook;
	Vector3 ball;
	Vector3 peg;


	void Start()
	{
		hook = GameObject.Find ("Test").GetComponent<Hook>();
		ball = GameObject.Find ("Test").GetComponent<Rigidbody2D>().transform.position;
	}

	void FixedUpdate () 
	{
		//transform.position = new Vector3(transform.position.x,transform.position.y-0.1f,transform.position.z);
		if (transform.position.y <= -7f) 
		{
			Destroy (gameObject);
		}
		if (gameObject.layer == 10 && hook.mousePos.x != transform.position.x)
		{
			ball = GameObject.Find ("Test").GetComponent<Rigidbody2D>().transform.position;
			peg = transform.position;

			if (Vector3.Distance (ball, peg) >= 1) 
			{
				Debug.Log ("DISTANCE");
				gameObject.layer = 9;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Ball") 
		{
			ghostNumber = 3;
		}

		for(int i = 0; i < 2; i++)
		{
			if (col.gameObject.tag == "Ghost" + i) 
			{
				ghostNumber = i;
				break;
			}
		}

		if (ghostNumber <= 1 && col.gameObject.tag == "Ghost" + ghostNumber) 
		{
			GameObject.FindGameObjectWithTag ("Ghost" + 0).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 0).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag ("Ghost" + 1).GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag ("Ghost" + 1).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().velocity;
			GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity = GameObject.FindGameObjectWithTag ("Ghost" + ghostNumber).GetComponent<Rigidbody2D> ().angularVelocity;
		}
		else if(ghostNumber == 3)
		{
			GameObject.FindGameObjectWithTag("Ghost" + 0).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 0).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;

			GameObject.FindGameObjectWithTag("Ghost" + 1).GetComponent<Rigidbody2D> ().velocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().velocity;
			GameObject.FindGameObjectWithTag("Ghost" + 1).GetComponent<Rigidbody2D> ().angularVelocity = GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().angularVelocity;
		}
	}
}
