using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.EventSystems;

[RequireComponent (typeof (PolygonCollider2D))]
[RequireComponent (typeof (MouseOverZoom))]

public class ChangeLuaVariableOnClick : MonoBehaviour {

	public string luaVariable;
	public bool targetValue = true;

	void OnMouseDown() {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			print (DialogueLua.GetVariable (luaVariable).AsBool);
			DialogueLua.SetVariable (luaVariable, targetValue);
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
