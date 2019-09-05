using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ResetLuaVariables : MonoBehaviour {

	public string level;

	private string[] variablesToReset;

	// Use this for initialization
	void Start () {
		switch(level){
			case "fra":
				variablesToReset = new string[ ] { "fra_hostel_checkin", 
					"fra_station_can_buy_ticket", 
					"fra_cafe_completed", 
					"fra_got_sandwich", 
					"fra_got_souvenir", 
					"fra_can_leave_zeil", 
					"fra_zeil_met_marie", 
					"fra_elevator_arrived", 
					"fra_elevator_coming", 
					"fra_elevator_stuck"
				};
				DialogueLua.SetVariable ("fra_zeil_interview_count", 0);
				break;
			case "bcn":
				variablesToReset = new string[ ] { "marketTalked", "museumTalked", "canet_street" };
				DialogueLua.SetVariable ("canet_talks", 0);
				break;
			case "lux":
				variablesToReset = new string[ ] { "lux_mudam_recept",
					"lux_swiss_talked_italian",
					"lux_swiss_talked_arnold",
					"lux_swiss_talked_malik",
					"lux_swiss_talked_twogirls",
					"lux_hostel",
					"lux_shopped",
					"lux_hub_talked_pub"
				};
				break;
		}

		for (int i = 0; i < variablesToReset.Length; i++){
			DialogueLua.SetVariable (variablesToReset[i], false);
		}
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
