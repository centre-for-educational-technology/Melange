using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class StartConversation : MonoBehaviour {

	public static GameObject matt;
	public static GameObject paul;
	public static GameObject richard;
	public static GameObject tariq;
	public static GameObject chris;

	public static GameObject mattSMS;

	//[ConversationPopup(true)]
	public string conversation; // Shown WITH database selection field.

	public void StartConversation2(string conversation) {
		DialogueManager.StartConversation(conversation);
		//GameObject.Find ("Menu screens (canvas)").SetActive (false);
		if (conversation == "#01b_CheckOutThisContest") {
			matt.SetActive (true);
		} else if (conversation == "#02a_SellingStuff") {
			richard.SetActive (true);
		} else if (conversation == "#02b_SellingStuff") {
			chris.SetActive (true);
		} else if (conversation == "#04_LookingForWork") {
			paul.SetActive (true);
		} else if (conversation == "#03_BorrowingMoneyFromDada") {
			tariq.SetActive (true);
		}
	}

	public void closeAllBigHeads(Transform actor){
		if (GameObject.Find ("Pad")) {
			matt.SetActive (false);
		}
	}

	public void ShowSMS(string person) {
		if (person == "matt") {
			mattSMS.SetActive (true);
			DialogueLua.SetVariable ("matthew", true);
		}
	}

	// Use this for initialization
	void Awake () {
		matt = GameObject.Find ("MatthewBig");
		matt.SetActive (false);
		paul = GameObject.Find ("PaulBig");
		paul.SetActive (false);
		richard = GameObject.Find ("RichardBig");
		richard.SetActive (false);
		tariq = GameObject.Find ("TariqBig");
		tariq.SetActive (false);
		chris = GameObject.Find ("ChrisBig");
		chris.SetActive (false);

		mattSMS = GameObject.Find ("MessageMatt");
		mattSMS.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
