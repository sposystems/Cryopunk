using UnityEngine;
using System.Collections;

public class FancyAnimations : MonoBehaviour {

	//public GameObject movingObject;
	public Vector3 pointA;
	public Vector3 pointB;
	public float timeFloat;
	
	IEnumerator Start()
	{
		yield return StartCoroutine (Wait (39));
		//var pointA = transform.position;
		//while (true) {
			//yield return StartCoroutine(MoveObject(transform, pointA, pointB, timeFloat));
			//yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		//}
	}

	IEnumerator Wait(float seconds){
		Debug.Log ("Waited for " + seconds + " seconds.");
		yield return new WaitForSeconds(seconds);
		yield return StartCoroutine(MoveObject(transform, pointA, pointB, timeFloat));
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.2f;
		var rate= 0.2f/time;
		while (i < time) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		//movingObject.transform.position = Vector3.Lerp(10, 0, 0);
		//movingObject.transform.position = Vector3.Lerp(-20 , 0, 0);
	}

}
