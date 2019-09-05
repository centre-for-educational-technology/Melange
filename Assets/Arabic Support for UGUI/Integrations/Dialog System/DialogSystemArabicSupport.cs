using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
#if Dialog_System_for_Unity_Arabic
using PixelCrushers.DialogueSystem;
#endif
namespace StrangerGames.ArabicSystemUGUI
{
    public class DialogSystemArabicSupport : MonoBehaviour
    {
#if Dialog_System_for_Unity_Arabic
        public string DialogSystemRtlLangCode;

        // Use this for initialization
        void OnTextChange(Text label)
        {
            if(Localization.Language == DialogSystemRtlLangCode)
            {
                var typewriterEffect = label.GetComponent<UnityUITypewriterEffect>();
                if (typewriterEffect != null) typewriterEffect.rightToLeft = true;
#if VN_for_DS_Unity_Arabic
                var VNtypewriterEffect = GetComponent<StrangerGames.VNForDS.VNForDSTypeWriterEffect>();
                if (VNtypewriterEffect != null) VNtypewriterEffect.rightToLeft = true;
#endif
                UIRTLText uirtlText = label.GetComponent<UIRTLText>();
                if (uirtlText != null)
                {
                    uirtlText.textString = label.text;
                }
            }
        }
#endif
    }
}
