using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellAppController : MonoBehaviour {

	public static GameObject richardAd;
	public static GameObject chrisAd;

	private GameObject richardContact;
	private GameObject chrisContact;
	private GameObject chrisSMS;

	public void ShowAd(string ad){
		if (ad == "richard") {
			richardAd.SetActive (true);
			richardContact.SetActive (true);
		} else if (ad == "chris") {
			chrisAd.SetActive (true);
			chrisContact.SetActive (true);
			chrisSMS.SetActive (true);
		}
	}

	// Use this for initialization
	void Awake () {
		richardAd = GameObject.Find ("RichardAd");
		chrisAd = GameObject.Find ("ChrisAd");
		richardAd.SetActive (false);
		chrisAd.SetActive (false);

		richardContact = GameObject.Find ("ContactRichard");
		chrisContact = GameObject.Find ("ContactChris");
		chrisSMS = GameObject.Find ("SMSContactChris");
		richardContact.SetActive (false);
		chrisContact.SetActive (false);
		chrisSMS.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
