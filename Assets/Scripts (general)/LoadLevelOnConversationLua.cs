using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class LoadLevelOnConversationLua : MonoBehaviour {

	public string scene;
	public string luaTrigger;
	public string luaTrigger2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(DialogueLua.GetVariable(luaTrigger).AsBool == true){
			SceneManager.LoadScene(scene);
		};
	}
}
