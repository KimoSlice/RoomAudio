﻿using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if(carrying) {
			carry(carriedObject);
			checkDrop();
			//rotateObject();
		} else {
			pickup();
		}
	}
	
	//void rotateObject() {
		//carriedObject.transform.Rotate(5,10,15);
	//}
	
	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}
	
	void pickup() {
		if(Input.GetMouseButtonDown(1)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			
			Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				GRAB p = hit.collider.GetComponent<GRAB>();
				if(p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					//p.gameObject.rigidbody.isKinematic = true;
				}
			}
		}
	}
	
	void checkDrop() {
		if(Input.GetMouseButtonDown(1)) {
			dropObject();
		}
	}
	
	void dropObject() {
		carrying = false;
		GetComponent<Rigidbody>().isKinematic = false;
		carriedObject = null;
	}
}

