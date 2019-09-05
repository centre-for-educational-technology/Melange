using UnityEngine;
using System.Collections;

public class TrainAnimation : MonoBehaviour {

	public Vector3 stopPosition;
	public float speed = 1;

	private bool arrived = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (!arrived) {
			Arrive ();
		} else {
			OpenDoors ();
		}

	}

	private void Arrive() {
		//the speed, in units per second, we want to move towards the target
		//move towards the center of the world (or where ever you like)
		Vector3 targetPosition = stopPosition;

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
			arrived = true;
		}
	}

	private void OpenDoors(){

	}
}
