﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Script : MonoBehaviour {

	public bool grabbed;
	RaycastHit2D hit;
	public float distance=2f;
	public float throwForce;
	public Transform holdPoint;
	public Transform rayPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.V)){

			if(!grabbed) {
				Physics2D.queriesStartInColliders = false;
				hit = Physics2D.Raycast (rayPoint.position, Vector2.right * transform.localScale.x,distance);

				if(hit.collider !=null && hit.collider.tag=="grabbable"){
					grabbed = true;
				}


			} 
			else {
				//throw
				grabbed=false;
				if(hit.collider.gameObject.GetComponent<Rigidbody2D>() !=null) {
					hit.collider.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x, 2) * throwForce;
				}
			}
		}

		if (grabbed)
			hit.collider.gameObject.transform.position = holdPoint.position;
		
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawLine (rayPoint.position, rayPoint.position + Vector3.right * rayPoint.localScale.x * distance);
	}
}
