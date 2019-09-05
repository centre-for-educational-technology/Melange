using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class KitchenDoorClick : MonoBehaviour {

	public string scene;

	void OnMouseDown() {
		print ("Door clicked");
		if(DialogueLua.GetVariable("hasMoney").AsBool == true){
			SceneManager.LoadScene(scene);
		};
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
