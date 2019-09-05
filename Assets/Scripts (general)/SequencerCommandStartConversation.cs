using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands {

	public class SequencerCommandStartConversation : SequencerCommand { // Rename to SequencerCommand<YourCommand>

		public void Start() {
			string convoName = GetParameter(0);
			if (!string.IsNullOrEmpty(convoName)) {
				DialogueManager.StopConversation ();
				DialogueManager.StartConversation(convoName);
			}
            Stop();
		}
			
	}

}
 

/**/