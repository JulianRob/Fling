using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour 
{
	// Creates a line renderer that follows a Sin() function
	// and animates it.

	public int lengthOfLineRenderer = 2;
	bool isPressed = false;

	Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.widthMultiplier = 0.2f;
		lineRenderer.positionCount = lengthOfLineRenderer;
		lineRenderer.useWorldSpace = true;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			isPressed = true;
		}

		if (Input.GetMouseButtonDown (1)) 
		{
			isPressed = false;
		}

		if (isPressed == true) 
		{
			LineRenderer lineRenderer = GetComponent<LineRenderer>();
			var points = new Vector3[lengthOfLineRenderer];
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			points[0] = new Vector3(rb2d.transform.position.x,rb2d.transform.position.y,0);
			points[1] = new Vector3(mousePos.x,mousePos.y,0);
			lineRenderer.SetPositions(points);
		}
	}
}
