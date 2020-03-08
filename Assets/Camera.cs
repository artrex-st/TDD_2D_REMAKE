﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public Transform PlayerTransform; // Player Transform
	public Transform CameraTransform; // Camera Transform
	//public GameObject PlayerObject; // Capturar obj Do player


	// Use this for initialization
	void Start()
	{
		PlayerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
		CameraTransform = GetComponent<Transform>();

	}

	// Update is called once per frame
	void Update()
	{
		CameraTransform.position = Vector3.Lerp(
			CameraTransform.position,
			new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, CameraTransform.position.z), 0.03f);


	}
}
