using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour {
	[SerializeField] float rcsThurst = 100f;
	[SerializeField] float mainThurst = 100f;
	
	Rigidbody rigidBody;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Rotate();
		Thurst();
		
	}

	private void Rotate() {
		rigidBody.freezeRotation = true;

		
		float rotationSpeed = rcsThurst * Time.deltaTime;
		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate(Vector3.forward*rotationSpeed);
		}
		else if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(-Vector3.forward*rotationSpeed);
		}

		rigidBody.freezeRotation = false;
	}

	private void Thurst() {
		if (Input.GetKey(KeyCode.Space)) {
			rigidBody.AddRelativeForce(Vector3.up*mainThurst);
			if (!audioSource.isPlaying) {
				// so it doesn't layer
				audioSource.Play();
			}
		} else {
			audioSource.Stop();
		}
	}
}
