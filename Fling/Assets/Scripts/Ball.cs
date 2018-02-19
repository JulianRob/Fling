using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D hook;

	private int pegRate = 60;

	public GameObject peg;

	public float releaseTime = 0.15f;
	public float maxDragDistance = 2f;

	private bool stop = false;

	private bool isPressed = false;

	void Update ()
	{
		if (isPressed) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if (Vector3.Distance (mousePos, hook.position) > maxDragDistance) 
			{
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			} 
			else 
			{
				rb.position = mousePos;
			}
		}
	}

	void OnMouseDown ()
	{
		if (stop == false)
		{
			isPressed = true;
			rb.isKinematic = true;
		}
	}

	void OnMouseUp()
	{
		isPressed = false;
		rb.isKinematic = false;
		StartCoroutine (Release ());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds (releaseTime);
		GetComponent<SpringJoint2D> ().enabled = false;
		this.enabled = false;
		stop = true;
	}

	void FixedUpdate()
	{
		if (pegRate >= 60) 
		{
			Instantiate (peg, new Vector3 (Random.Range (-2f, 2f), 6f, 0f), peg.transform.rotation);
			pegRate = 0;
		} 
		else 
		{
			pegRate += 1;
		}
	}
}
