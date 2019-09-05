using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.EventSystems;

[RequireComponent (typeof (PolygonCollider2D))]
[RequireComponent (typeof (MouseOverZoom))]

public class StartConversationOnClick : MonoBehaviour {

	//public string conversation2; // Shown without database selection field.

	[ConversationPopup(true)] // Shown WITH database selection field.

	public string conversation; 

	[Header("Conditions")]
	public bool luaCondition;
	public string luaVariable;
	public string disablingVariable;
	public bool playAudio;
	public AudioClip audioFile;
	public AudioClip disablingAudio;

	private AudioSource audioSource;

	void OnMouseDown(){
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			//Debug.Log (conversation);
			if (luaCondition) {
				if(DialogueLua.GetVariable (disablingVariable).AsBool == true && !Input.GetKey (KeyCode.O)){
					if (playAudio && !audioSource.isPlaying) {
						audioSource.PlayOneShot (disablingAudio);
					}
				} else if(DialogueLua.GetVariable (luaVariable).AsBool == true || Input.GetKey (KeyCode.O)){
					DialogueManager.StartConversation(conversation);
				} else if (playAudio && !audioSource.isPlaying) {
					audioSource.PlayOneShot (audioFile);
				}
			} else {
				DialogueManager.StartConversation(conversation);
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
