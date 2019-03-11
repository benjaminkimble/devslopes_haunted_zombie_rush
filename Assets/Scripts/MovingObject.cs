using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
	[SerializeField] private float objectSpeed = 1.5f;
	[SerializeField] private float resetPosition = 0.0f;
	[SerializeField] private float startPosition = 0.0f;
	
	// Update is called once per frame
	protected virtual void Update () {
		MoveLeft();
	}

	private void MoveLeft() {
		if (GameManager.Instance.PlayerActive) {
			transform.Translate(Vector3.left *
			                    (objectSpeed * Time.deltaTime));
			if (transform.localPosition.x <= resetPosition) {
				Vector3 newPosition = new Vector3(startPosition,
					transform.position.y, transform.position.z);
				transform.position = newPosition;
			}
		}
	}
}
