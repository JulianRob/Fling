using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour 
{
	public List<Vector2> newVerticies = new List<Vector2>();
	private EdgeCollider2D col;

	public int lengthOfLineRenderer = 2;
	bool isPressed = false;

	float x;
	float y;
	float difference1;
	float difference2;
	float ratio;
	float rate1;
	float rate2;

	float identical;
	float identical2;

	private Vector3 start;
	private Vector3 end;

	public Material rope;

	bool restart = false;

	float change = 0.1f;

	bool hit = false;
	bool locked = false;
	float timer = 0;
	public Vector3 mousePos;

	Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.widthMultiplier = 0.2f;
		lineRenderer.positionCount = lengthOfLineRenderer;
		lineRenderer.useWorldSpace = true;

		x = rb2d.transform.position.x;
		y = rb2d.transform.position.y;

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void Awake() {
		col = GetComponent<EdgeCollider2D>();
		newVerticies.Add( new Vector2(-0.5f, -0.5f) );
		newVerticies.Add( new Vector2(0.5f, -0.5f) );
	}

	void setPoints() 
	{
		col.points = newVerticies.ToArray();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			isPressed = true;
		}

		if (hit == true) 
		{
			transform.position = Vector3.Lerp (start,end,timer);
		}
	}

	void FixedUpdate()
	{
		if (hit == true) 
		{
			if (timer == 1) 
			{
				hit = false;
				isPressed = false;
				locked = false;
				timer = 0;
			}
			timer += .01f;
			if (timer >= 1) 
			{
				timer = 1;
			}
		}

		if (isPressed == true) 
		{
			identical = x;
			identical2 = y;

			LineRenderer lineRenderer = GetComponent<LineRenderer>();
			var points = new Vector3[lengthOfLineRenderer];
		
			if (locked == false) 
			{
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				locked = true;
			}
			
			points[0] = new Vector3(rb2d.transform.position.x,rb2d.transform.position.y,0);

			//FIND RATES
			difference1 = Mathf.Abs(mousePos.x - x);
			difference2 = Mathf.Abs (mousePos.y - y);
			if (difference1 != 0 && difference2 != 0) 
			{
				if (difference1 / difference2 < difference2 / difference1) 
				{
					ratio = difference1 / difference2;
					rate1 = ratio * change;
					rate2 = change;
				} 
				else
				{
					ratio = difference2 / difference1;
					rate1 = change;
					rate2 = ratio* change;
				}
			} 
			else 
			{
				rate1 = change;
				rate2 = change;
			}
				
			if (x < mousePos.x) 
			{
				x += rate1;
			}

			if (x > mousePos.x) 
			{
				x -= rate1;
			}

			if (y < mousePos.y) 
			{
				y += rate2;
			}

			if (y > mousePos.y) 
			{
				y -= rate2;
			}
			points [1] = new Vector3 (x, y, 0);
			lineRenderer.SetPositions (points);
			lineRenderer.material = rope;
			lineRenderer.textureMode = LineTextureMode.Tile;
			newVerticies.Clear ();
			newVerticies.Add (new Vector2 (0, 0));
			newVerticies.Add (new Vector2 (x - rb2d.transform.position.x, y - rb2d.transform.position.y));
			setPoints ();   

			if (restart == true && (x == identical || y == identical2))
			{
				isPressed = false;
				locked = false;
				restart = false;
				identical = x + 10;;
			}

			if (x == identical && hit == false) 
			{
				mousePos = new Vector3 (rb2d.transform.position.x, rb2d.transform.position.y, 0);
				restart = true;
			}
		
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//Destroy (col.gameObject);
		if (col.gameObject.layer == 9) 
		{
			start = new Vector3 (rb2d.transform.position.x,rb2d.transform.position.y,rb2d.transform.position.z);
			end = new Vector3 (col.gameObject.transform.position.x,col.gameObject.transform.position.y,0);
			mousePos = new Vector3 (col.gameObject.transform.position.x,col.gameObject.transform.position.y,0);
			col.gameObject.layer = 10;
			hit = true;
		}
	}
}
