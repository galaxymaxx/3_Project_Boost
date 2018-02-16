﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour {
	Rigidbody rigidBody;

	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

	private void ProcessInput() {
		if (Input.GetKey(KeyCode.Space)) {
			rigidBody.AddRelativeForce(Vector3.up);
			if (!audioSource.isPlaying) {	// so it doesn't layer
				audioSource.Play();
			}
		} else {
			audioSource.Stop();
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate(Time.deltaTime*Vector3.forward);
		}
		else if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(Time.deltaTime*-Vector3.forward);
		}
	}
}
