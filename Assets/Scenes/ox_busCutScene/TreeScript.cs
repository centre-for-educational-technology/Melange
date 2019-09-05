using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {

	public float smoothTime = 3f;
	public float xVel = 0f;
	public float yVel = 0f;
	public float zVel = 0f;

	private Vector3 endPosition = new Vector3 (-41f, 0f, -2f);



	void OnMouseDown(){

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

			float time = smoothTime * Time.deltaTime * 10;
			
			AnimatePosition(endPosition, time);


	}

	void AnimatePosition(Vector3 toPosition, float time){
		float newX = Mathf.SmoothDamp(transform.localPosition.x, toPosition.x, ref xVel, time);
		float newY = Mathf.SmoothDamp(transform.localPosition.y, toPosition.y, ref yVel, time);
		
		transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
	}
	

}
