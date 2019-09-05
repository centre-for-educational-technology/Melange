using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.EventSystems;

[RequireComponent (typeof (PolygonCollider2D))]
[RequireComponent (typeof (MouseOverZoom))]

public class PlayAudioOnClick : MonoBehaviour {

	public AudioClip primaryAudio;
	public bool changeOnCondition;
	public string luaVariable;
	public AudioClip conditionMetAudio;
	public string disablingVariable;
	public AudioClip disablingAudio;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			if (!audioSource.isPlaying) {
				if (!string.IsNullOrEmpty(disablingVariable) && DialogueLua.GetVariable (disablingVariable).AsBool == true) {
					audioSource.PlayOneShot (disablingAudio);
				} else if (changeOnCondition && DialogueLua.GetVariable (luaVariable).AsBool == true) {
					audioSource.PlayOneShot (conditionMetAudio);
				} else {
					audioSource.PlayOneShot (primaryAudio);
				}
			};
		}

	}
}
