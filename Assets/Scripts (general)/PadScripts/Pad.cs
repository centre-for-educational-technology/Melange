using UnityEngine;
using System.Collections;

public class Pad : MonoBehaviour {

	public static GameObject list;
	public static GameObject messages;
	public static GameObject settings;
	public static GameObject sellApp;

	public static GameObject notifications;

	public static void HideAllScreens(){
		list.SetActive (false);
		messages.SetActive (false);
		settings.SetActive (false);
		SellAppController.chrisAd.SetActive (false);
		SellAppController.richardAd.SetActive (false);
		sellApp.SetActive (false);
		StartConversation.mattSMS.SetActive (false);
	}

	public static void HideNotifications(){
		notifications.SetActive (false);
	}
		
	void Awake() {
		list = GameObject.Find ("ContactListScreen");
		messages = GameObject.Find ("MessageScreen");
		settings = GameObject.Find ("SettingsScreen");
		sellApp = GameObject.Find ("SellUrStuff");
		HideAllScreens ();

		notifications = GameObject.Find ("NotificationDot");
	}
}
