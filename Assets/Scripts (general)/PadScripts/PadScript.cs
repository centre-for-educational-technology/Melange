using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PadScript : MonoBehaviour {

	public float smoothTime = 0.3f;
	public float scaleVel = 0f;
	public float xVel = 0f;
	public float yVel = 0f;

	private bool closing = false;

	private Vector3 startScale = new Vector3 (0f, 0f, 1f);
	private Vector3 endScale = new Vector3 (1f, 1f, 1f);
	private Vector3 startPosition;
	private Vector3 endPosition = new Vector3 (0f, 0f, -0.5f);

	private GameObject smallPad;
	private GameObject bigPad;


	// Use this for initialization
	void Awake () {
		bigPad = GameObject.Find ("Pad");
		bigPad.transform.localScale = startScale;
	}

	void OnEnable(){
		if(GameObject.Find("smallpad")){
			smallPad = GameObject.Find("smallpad");
			startPosition = new Vector3 (2.67f, -1.6f, -0.5f);
		} else if (GameObject.Find("pad-button")){
			smallPad = GameObject.Find("pad-button");
			startPosition = smallPad.transform.position;
		}
		Pad.HideAllScreens ();
		bigPad.transform.localPosition = startPosition;
	}

	// Update is called once per frame
	void Update () {
		if(bigPad.transform.localScale.x < 1f && !closing) {
			float time = smoothTime * Time.deltaTime * 10;

			AnimatePosition(endPosition, time);
			AnimateScale(endScale, time);
		} else if(bigPad.transform.localScale.x > 0.05f && closing) {
			float time = smoothTime * Time.deltaTime * 10;
			
			AnimatePosition(startPosition, time);
			AnimateScale(startScale, time);
		} else if(closing){
			closing = false;
			if (smallPad) {
				smallPad.SetActive (true);
			}
			bigPad.SetActive(false);
		}
	}

	void OnMouseDown(){
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			closing = true;
			Pad.HideAllScreens ();
		}

	}

	void AnimatePosition(Vector3 toPosition, float time){
		float newX = Mathf.SmoothDamp(bigPad.transform.localPosition.x, toPosition.x, ref xVel, time);
		float newY = Mathf.SmoothDamp(bigPad.transform.localPosition.y, toPosition.y, ref yVel, time);

		bigPad.transform.localPosition = new Vector3(newX, newY, bigPad.transform.localPosition.z);
	}

	void AnimateScale(Vector3 toScale, float time){
		float newScale = Mathf.SmoothDamp(bigPad.transform.localScale.x, toScale.x, ref scaleVel, time);
		
		bigPad.transform.localScale = new Vector3(newScale, newScale, bigPad.transform.localScale.z);
	}
}
