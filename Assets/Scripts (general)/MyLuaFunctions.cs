using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class MyLuaFunctions : MonoBehaviour {
	void OnEnable() {
		Lua.RegisterFunction("LoadLevel", this, typeof(MyLuaFunctions).GetMethod("LoadLevel"));
		Lua.RegisterFunction("StartConversation", this, typeof(MyLuaFunctions).GetMethod("StartConversation"));
	}

	void OnDisable() {
		Lua.UnregisterFunction("LoadLevel");
		Lua.UnregisterFunction("StartConversation");
	}

	public void LoadLevel(string name) {
		SceneManager.LoadScene (name);
	}

	public void StartConversation(string name, string delay) {
		if (!string.IsNullOrEmpty(name)) {
			DialogueManager.StopConversation ();
			if(delay != null){
				StartCoroutine (delayConvo (name, int.Parse(delay)));
			} else {
				DialogueManager.StartConversation(name);
			}


		}
	}

	IEnumerator delayConvo(string name, int sec)
	{
		yield return new WaitForSeconds(sec);
		DialogueManager.StartConversation(name);
	}
}
