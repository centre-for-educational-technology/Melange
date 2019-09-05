using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.EventSystems;

[RequireComponent (typeof (PolygonCollider2D))]
[RequireComponent (typeof (MouseOverZoom))]

public class TravelOnClick : MonoBehaviour {

	public string destination;
	[Header("Conditions")]
	public bool luaCondition;
	public bool luaConditionNOT;
	public string luaVariable;
	public bool playAudio;
	public AudioClip audioFile;

	private AudioSource audioSource;

	void OnMouseDown() {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			//print (DialogueLua.GetVariable (luaVariable).AsBool);
			if ((luaCondition && !luaConditionNOT && DialogueLua.GetVariable (luaVariable).AsBool == true) || (luaCondition && luaConditionNOT && DialogueLua.GetVariable (luaVariable).AsBool == false) || Input.GetKey (KeyCode.O)) {
				DialogueLua.SetVariable ("map_destination", destination);
			} else if (playAudio && !audioSource.isPlaying) {
				audioSource.PlayOneShot (audioFile);
			} else if(!luaCondition){
				DialogueLua.SetVariable ("map_destination", destination);
			};
		}
	}
	
	// Use this for initialization
	void Start () {
		if (playAudio) {
			audioSource = gameObject.AddComponent<AudioSource>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
