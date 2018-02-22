using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	public List<Vector2> newVerticies = new List<Vector2>();
	private EdgeCollider2D col;

	void Awake() {
		col = GetComponent<EdgeCollider2D>();
		newVerticies.Add( new Vector2(-0.5f, -0.5f) );
		newVerticies.Add( new Vector2(0.5f, -0.5f) );
		newVerticies.Add( new Vector2(0.5f, 0.5f) );
		newVerticies.Add( new Vector2(-0.5f, 0.5f) );
		newVerticies.Add( new Vector2(-0.5f, -0.5f) );
	}
		
	void setPoints() {
		col.points = newVerticies.ToArray();
	}

	// Update is called once per frame
	void Update () {
		setPoints();    
	}
}
