using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour {

	public Sprite offSprite;
	public Sprite onSprite;
	public string switchText;

	Animator panelAnimation;
	private Button thisButton;

	private UnityEngine.UI.Text textField;
	public UnityEngine.UI.Image buttonImage;
	private  UnityEngine.UI.Image originalImage;
	private string originalText;

	private bool isSound = true;

	void Start () {
		thisButton = GetComponent<Button> ();
		textField = thisButton.GetComponentInChildren<Text>();
		originalText = textField.text;
	}

	void Update () {
		
	}

	public void OnClickSound() {
		Debug.Log("Sound Button Clicked");
		if (isSound) {
			textField.text = switchText;
			buttonImage.sprite = offSprite;
			AudioListener.volume = 0.0f;
			isSound = false;
		} else {
			textField.text = originalText;
			buttonImage.sprite = onSprite;
			AudioListener.volume = 1.0f;
			isSound = true;
		}

		//Open Panel Animation
		//panelAnimation.SetInteger("isOpen", 1);
	}

	public void OnPanelCloseButton()
	{
		//close panel animation
		//panelAnimation.SetInteger("isOpen", 0);
	}
}