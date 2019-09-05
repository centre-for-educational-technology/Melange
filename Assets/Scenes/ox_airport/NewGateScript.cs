using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class NewGateScript : MonoBehaviour {

	public Vector3 openPosition;
	private bool open;
	private GameObject gateRibbon;

	// Use this for initialization
	void Start () {
		gateRibbon = GameObject.Find("gateRibbon");
		gateRibbon.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(DialogueLua.GetVariable("airport_checkin").AsBool == true){
			if(!open) {
				MoveTowardsTarget ();
				gateRibbon.SetActive (true);
			} 
		}
	}

	private void MoveTowardsTarget() {
		//the speed, in units per second, we want to move towards the target
		float speed = 1;
		//move towards the center of the world (or where ever you like)
		Vector3 targetPosition = openPosition;

		Vector3 currentPosition = this.transform.position;
		//first, check to see if we're close enough to the target
		if (Vector3.Distance (currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize ();
			//scale the movement on each axis by the directionOfTravel vector components

			this.transform.Translate (
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		} else {
			open = true;
		}
	}
}
