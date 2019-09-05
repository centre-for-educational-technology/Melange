using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace StrangerGames.ArabicSystemUGUI
{
    public class BasicArabicProcessor : MonoBehaviour
    {
        public enum ArabicLibrary
        {
            Default,
#if Arabic_Support_for_Unity_Arabic
            ArabicSystemForUnity,
#endif
#if NUIAR_RTL
            NUIAR
#endif
        }

        [Multiline]
        public string arabicText;

        public ArabicLibrary libraryForConversion;

#if NUIAR_RTL
        [Header("NUIAR_RTL Settings")]
        [Tooltip("Number format in converted text (1,2,3 or ١,٢,٣)")]
	    public RTL.NumberFormat NumberFormat = RTL.NumberFormat.KeepOriginalFormat;
        [Tooltip("True value means the main context is English(any left to right) text including some Arabic (any right to left) words inside.")]
        public bool IsLtrText = false;
#endif
#if Arabic_Support_for_Unity_Arabic
        [Header("Arabic Support for Unity Settings")]
        [Tooltip("Only if you use Arabic Support for Unity")]
        public bool showTashkeel;
        [Tooltip("Only if you use Arabic Support for Unity")]
        public bool useHinduNumbers;
#endif

        // Use this for initialization
        void Start()
        {
            string convertedText;
            switch (libraryForConversion)
            {
#if Arabic_Support_for_Unity_Arabic
                    case ArabicLibrary.ArabicSystemForUnity:
                        convertedText = ArabicSupport.ArabicFixer.Fix(arabicText, showTashkeel, useHinduNumbers);
                        break;
#endif
#if NUIAR_RTL
                    case ArabicLibrary.NUIAR:
                        convertedText = RTL.Convert (arabicText, NumberFormat, IsLtrText);
                        break;
#endif
                case ArabicLibrary.Default:
                    //convertedText = ArabicConverter.convertArabic(arabicText);
                    convertedText = ArabicReshape.reshape(arabicText);
                    break;
                default:
                    //convertedText = ArabicConverter.convertArabic(arabicText);
                    convertedText = ArabicReshape.reshape(arabicText);
                    break;
            }
            GetComponent<Text>().text = convertedText;
        }
    }
}