using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
using UnityEngine.EventSystems;

public class TramAnimation : MonoBehaviour {

	public Vector3 stopPosition;
	public Vector3 leavePosition;
	public string nextLevel;
	public float speed = 1;
	public float leavingSpeed = 5;
	public AudioClip audioFile;

	private bool arrived = false;
	private bool leaving = false;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		if (DialogueLua.GetVariable ("ist_touristoffice").AsBool == true) {
			this.transform.position = stopPosition;
			arrived = true;
		} else {
			audioSource = gameObject.AddComponent<AudioSource>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (!arrived) {
			Arrive ();
		} else if (leaving){
			Leave();
		}

	}

	void OnMouseDown(){
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			if (DialogueLua.GetVariable ("ist_touristoffice").AsBool == true) {
				leaving = true;
			} else {
				if(!audioSource.isPlaying) {
					audioSource.PlayOneShot (audioFile);
				}
			}
		}
	}

	private void Arrive() {
		//the speed, in units per second, we want to move towards the target
		//move towards the center of the world (or where ever you like)
		Vector3 targetPosition = stopPosition;

		Vector3 currentPosition = this.transform.position;
		// first, check to see if we're close enough to the target
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

	private void Leave(){
		if (this.transform.position != leavePosition) {
			transform.position = Vector2.MoveTowards (transform.position, leavePosition, leavingSpeed * Time.deltaTime);
		} else {
			SceneManager.LoadScene(nextLevel);
		}
	}
		
}
