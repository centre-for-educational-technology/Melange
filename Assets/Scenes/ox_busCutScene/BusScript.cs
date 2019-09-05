using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BusScript : MonoBehaviour {

	public float smoothTime = 7f;
	public float xVel = 0f;
	public float yVel = 0f;
	public float zVel = 0f;

	private Vector3 endPosition = new Vector3 (12f, 0f, -2f);



	void OnMouseDown(){

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

			float time = smoothTime * Time.deltaTime * 10;
			
			AnimatePosition(endPosition, time);

		if(endPosition.x - transform.localPosition.x  < 3){
			SceneManager.LoadScene("ox_airport_new");
		}

	}

	void AnimatePosition(Vector3 toPosition, float time){
		float newX = Mathf.SmoothDamp(transform.localPosition.x, toPosition.x, ref xVel, time);
		float newY = Mathf.SmoothDamp(transform.localPosition.y, toPosition.y, ref yVel, time);
		
		transform.localPosition = new Vector3(newX, newY, transform.localPosition.z);
	}
	

}
