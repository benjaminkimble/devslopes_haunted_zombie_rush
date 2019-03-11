﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacle : MovingObject {
	[SerializeField] private Vector3 topPosition;
	[SerializeField] private Vector3 bottomPosition;
	[SerializeField] private float speed = 1.0f;
	
	// Use this for initialization
	private void Start () {
		StartCoroutine(Move(bottomPosition));
	}

	private IEnumerator Move(Vector3 target) {
		while (Mathf.Abs((target - transform.localPosition).y) >
		       0.20f) {
			Vector3 direction = target.y == topPosition.y ?
				Vector3.up : Vector3.down;
			transform.localPosition +=
				direction * Time.deltaTime * speed;

			yield return null;
		}

		yield return new WaitForSeconds(0.5f);
		Vector3 newTarget = target.y == topPosition.y ?
			bottomPosition : topPosition;
		StartCoroutine(Move(newTarget));
	}
}
