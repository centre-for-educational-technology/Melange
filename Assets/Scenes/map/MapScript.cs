using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour {

	float speed = 0.5f;
	public Vector2 oxfTarget;
	public Vector2 bcnTarget;
	public Vector2 fraTarget;
	public Vector2 luxTarget;
	public Vector2 tllTarget;

	private Vector2 targetPos;

	private string departure;
	private string destination;
	private string targetLevel = "";

	// Use this for initialization
	void Start () {
		departure = DialogueLua.GetVariable ("map_departure").AsString;

		if(departure == "oxf"){
			transform.position = oxfTarget;
		} else if(departure == "bcn"){
			transform.position = bcnTarget;
		} else if(departure == "fra"){
			transform.position = fraTarget;
		} else if(departure == "lux"){
			transform.position = luxTarget;
		};
			
	}

	// Update is called once per frame
	void Update () {
		
		destination = DialogueLua.GetVariable ("map_destination").AsString;

		if(destination == "bcn"){
			targetPos = bcnTarget;
			targetLevel = "bcn_airport";
		} else if(destination == "fra"){
			targetPos = fraTarget;
			targetLevel = "fra_station";
		} else if(destination == "lux"){
			targetPos = luxTarget;
			targetLevel = "lux_info";
		} else if(destination == "tll"){
			targetPos = tllTarget;
			targetLevel = "tll_airport";
		};




		if(targetLevel != ""){
			if ((Vector2)transform.position != targetPos) {
				transform.position = Vector2.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);
			} else {
				DialogueLua.SetVariable ("map_departure", destination);
				DialogueLua.SetVariable ("map_destination", "");
				SceneManager.LoadScene(targetLevel);
			}
		}

	}
}
