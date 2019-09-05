using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.EventSystems;

[RequireComponent (typeof (PolygonCollider2D))]
[RequireComponent (typeof (MouseOverZoom))]

public class LoadLevelOnClick : MonoBehaviour {

	public string scene;
	[Header("Conditions")]
	public bool luaCondition;
	public bool luaConditionNOT;
	public string luaVariable;
	public bool playAudio;
	public AudioClip audioFile1;
	public AudioClip audioFile2;

	private int lastAudio = 1;
	private AudioSource audioSource;

	void OnMouseDown() {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			//print (DialogueLua.GetVariable (luaVariable).AsBool);
			if ((luaCondition && !luaConditionNOT && DialogueLua.GetVariable (luaVariable).AsBool == true) || (luaCondition && luaConditionNOT && DialogueLua.GetVariable (luaVariable).AsBool == false) || Input.GetKey (KeyCode.O)) {
				SceneManager.LoadScene (scene);
			} else if (playAudio && !audioSource.isPlaying) {
				if (audioFile2 != null && lastAudio == 1) {
					//audioSource.PlayClipAtPoint (audioFile2, Camera.main.transform.position);
					audioSource.PlayOneShot (audioFile2);
					lastAudio = 2;
				} else {
					//audioSource.PlayClipAtPoint(audioFile1, Camera.main.transform.position);
					audioSource.PlayOneShot (audioFile1);
					lastAudio = 1;
				}
			} else if(!luaCondition){
				SceneManager.LoadScene (scene);
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
