using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class ElevatorNumberCounter : MonoBehaviour {

	public string startVariable;
	public string endVariable;
	public Text text;

	private int seconds = 6;
	private bool started;

	private void startTimer(){
		InvokeRepeating ("Countdown", 1.0f, 1.0f);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (DialogueLua.GetVariable (startVariable).AsBool == true && !started) {
			started = true;
			startTimer ();
		}
	}

	void Countdown () {
		if (seconds < 0) {
			DialogueLua.SetVariable (endVariable, true);
			CancelInvoke ("Countdown");
		}

		if (seconds < 1) {
			text.text = "E";
		} else {
			text.text = "" + seconds;
		}

		seconds--;

	}
}
