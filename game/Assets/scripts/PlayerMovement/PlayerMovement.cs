using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed = 10.0f;
	public float rotateSpeed = 4.0f;

	void Update () {
		if (Input.GetKey ("w")) {
			transform.Translate((Vector3.forward)*moveSpeed*Time.deltaTime);
			Debug.Log ("The w key");
				}
		if (Input.GetKey ("s")) {
			transform.Translate((Vector3.back)*moveSpeed*Time.deltaTime);
			Debug.Log ("The s key");
		}
		if (Input.GetKey ("a")) {
			transform.Rotate(Vector3.down * rotateSpeed);
		
		}
		if (Input.GetKey ("d")) {
			transform.Rotate(Vector3.up * rotateSpeed);
		}
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log(Input.GetAxis("Fire1"));
			Debug.Log ("Pressing the Fire1 key");
				}

		if (Input.GetMouseButton (1)) {
			moveSpeed = 20.0f;
			Debug.Log("mouse button 1");//right mouse button
				}
		if (!Input.GetMouseButton (1)) {
			moveSpeed = 10.0f;
			Debug.Log("mouse button 1");//right mouse button
		}
		if (Input.GetMouseButton (0)) {
			Debug.Log("mouse button 0");//left mouse button
		}
	}
}
