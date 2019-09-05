using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent (typeof (PolygonCollider2D))]

public class MouseOverZoom : MonoBehaviour {

	private Vector2 startScale;
	private Vector2 endScale;
	private bool hovering;

	private float endWidth;
	private float endHeight;

	private GameObject self;

	public float scaleVel = 0f;
	public float zoomAmount = 1.05f;

	void OnMouseEnter()	{
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			hovering = true;
			Vector3 size = GetComponent<Renderer> ().bounds.size;
			//Debug.Log(size);
		}

	}
	void OnMouseExit() {
		hovering = false;
		Vector3 size = GetComponent<Renderer> ().bounds.size;
		//Debug.Log(size);
	}

	// Use this for initialization
	void Start () {
		startScale = transform.localScale;
		//Vector3 size = GetComponent<Renderer> ().bounds.size;
		//Debug.Log(size);
		endScale = new Vector2 (zoomAmount, zoomAmount);
	}

	void Update () {
		float time = 0.3f * Time.deltaTime * 10;

		if(hovering) {
			AnimateScale(endScale, time);
		} else if(!hovering){
			AnimateScale(startScale, time);
		}
	}

	void AnimateScale(Vector3 toScale, float time){
		float newScale = Mathf.SmoothDamp(transform.localScale.x, toScale.x, ref scaleVel, time);
		transform.localScale = new Vector3(newScale, newScale, transform.localScale.z);
	}
}
