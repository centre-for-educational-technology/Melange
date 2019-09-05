using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
#if NUIAR_RTL
using RTLService;
#endif
using System.Text;

namespace StrangerGames.ArabicSystemUGUI
{
    public class UIRTLText : MonoBehaviour
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
        public string setText;

		[Tooltip("Increase the margin if there is a new line error")]
		public int marginCharacterCount = 3;

        public ArabicLibrary libraryForConversion;

        public bool setTextAtStartUp = false;
        //public bool forceSet = false;
        string _textString = null;

        public bool processAsArabic = true;

        public string dynamicallyLoadedArabicFont;
        public Font arabicFont;

        public string textString
        {
            get
            {
                return _textString;
            }
            set
            {
                _textString = value;
                UpdateText();
            }
        }

        Text text;

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

        // Max characters per line - for wordwrapping the texts
        private int CharsPerLine = 30;

        void OnRectTransformDimensionsChange()
        {
            UpdateText();
        }

        void Start()
        {
            text = GetComponent<Text>();

            if (setTextAtStartUp)
            {
                textString = setText;
            }
        }

        int frames = 0;

        void Update()
        {
            frames++;
            if (frames == 30)
                UpdateText();
        }

        // Use this for initialization
        void UpdateText()
        {
            if (textString == null)
                return;
            text = GetComponent<Text>();
            if (processAsArabic)
            {
                if (text.alignment == TextAnchor.MiddleLeft)
                    text.alignment = TextAnchor.MiddleRight;
                else if (text.alignment == TextAnchor.LowerLeft)
                    text.alignment = TextAnchor.LowerRight;
                else if (text.alignment == TextAnchor.UpperLeft)
                    text.alignment = TextAnchor.UpperRight;

                if (!string.IsNullOrEmpty(dynamicallyLoadedArabicFont))
                    arabicFont = Resources.Load<Font>(dynamicallyLoadedArabicFont);

                if (text.font != arabicFont && arabicFont != null)
                    text.font = arabicFont;

                string convertedText;

                switch(libraryForConversion)
                {
#if Arabic_Support_for_Unity_Arabic
                    case ArabicLibrary.ArabicSystemForUnity:
                        convertedText = ArabicSupport.ArabicFixer.Fix(textString, showTashkeel, useHinduNumbers);
                        break;
#endif
#if NUIAR_RTL
                    case ArabicLibrary.NUIAR:
                        convertedText = RTL.Convert (textString, NumberFormat, IsLtrText);
                        break;
#endif
                    case ArabicLibrary.Default:
                        //convertedText = ArabicConverter.convertArabic(textString);
                        convertedText = ArabicReshape.reshape(textString);
                        break;
                    default:
                        //convertedText = ArabicConverter.convertArabic(textString);
                        convertedText = ArabicReshape.reshape(textString);
                        break;
                }

                Vector2 textBoxSize = text.rectTransform.rect.size * 0.91f;

                //Vector2 textBoxSize = new Vector2(LayoutUtility.GetPreferredWidth(text.rectTransform), LayoutUtility.GetPreferredHeight(text.rectTransform));

                TextGenerationSettings settings = text.GetGenerationSettings(textBoxSize);
				TextGenerator generator = text.cachedTextGenerator;
                generator.Populate(convertedText, settings);

                CharsPerLine = 0;
                int lastIndex = 0;
                foreach (UILineInfo lineInfo in generator.lines)
                {
                    int newLineLenght = lineInfo.startCharIdx - lastIndex;
                    if (CharsPerLine < newLineLenght)
                    {
                        CharsPerLine = newLineLenght;
                    }
                    lastIndex = lineInfo.startCharIdx;
                }

				for(int i = 0; i < marginCharacterCount; i++) {
					if (CharsPerLine > 1)
						CharsPerLine--;
				}

                if(CharsPerLine == 0 && generator.lines.Count > 0) {
                    CharsPerLine = convertedText.Length+2;
                }

                convertedText = WordWrap(textString, CharsPerLine);

                switch (libraryForConversion)
                {
#if Arabic_Support_for_Unity_Arabic
                    case ArabicLibrary.ArabicSystemForUnity:
                        convertedText = ArabicSupport.ArabicFixer.Fix(convertedText, showTashkeel, useHinduNumbers);
                        break;
#endif
#if NUIAR_RTL
                    case ArabicLibrary.NUIAR:
                        convertedText = RTL.ConvertCharacterWordWrapping (convertedText, CharsPerLine, NumberFormat, IsLtrText);
                        break;
#endif
                    case ArabicLibrary.Default:
                        //convertedText = ArabicConverter.convertArabic(convertedText);
                        convertedText = ArabicReshape.reshape(convertedText);
                        break;
                    default:
                        //convertedText = ArabicConverter.convertArabic(convertedText);
                        convertedText = ArabicReshape.reshape(convertedText);
                        break;
                }

                text.text = convertedText;
            }
            else {
                if (_textString != null)
                    text.text = _textString;
            }
        }

        string WordWrap(string wholeText, int myLimit)
        {
            StringBuilder newSentence = new StringBuilder();

            var lines = Regex.Split(wholeText, "\r\n|\r|\n");

            foreach (string sentence in lines)
            {
                string[] words = sentence.Split(' ');

                string line = "";
                foreach (string word in words)
                {
                    if ((line + word).Length > myLimit && line.Length > 0)
                    {
						line = line.Trim ();
                        newSentence.AppendLine(line);
                        line = "";
                    }

                    line += string.Format("{0} ", word);
                }

				if (line.Length > 0) {
					line = line.Trim ();
					newSentence.AppendLine (line);
				}
            }

            return newSentence.ToString().Trim('\n');
        }

        static bool IsASCII(string value)
        {
            // ASCII encoding replaces non-ascii with question marks, so we use UTF8 to see if multi-byte sequences are there
            return Encoding.UTF8.GetByteCount(value) == value.Length;
        }
    }
}
