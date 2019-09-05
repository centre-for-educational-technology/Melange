using UnityEngine;
using System.Collections;
using UnityEditor;

namespace StrangerGames.ArabicSystemUGUI
{
    public class IntegrationHelperEditor : IntegrationHelperEditorBase
    {
        [MenuItem("Tools/Arabic for Unity/Integrations", false, 0)]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<IntegrationHelperEditor>(true, "Integrations", true);
        }

        protected override void DrawIntegrations()
        {
            ShowIntegration("Dialog System for Unity",
                "Dialog System for Unity is the defacto standard for creating conversatoins/quests in Unity.", GetUrlForProductWithID("11672"), "Dialog_System_for_Unity_Arabic");

            ShowIntegration("Arabic Support for Unity",
                "Check here if you want to use Arabic Support for Unity version of Arabic text conversion.", GetUrlForProductWithID("2674"), "Arabic_Support_for_Unity_Arabic");

            /*ShowIntegration("Visual Novel for Dialog System for Unity",
                "Check here if you want to use Arabic Support for Visual Novel for Dialog System for Unity text conversion.", GetUrlForProductWithID("2674"),
                "VN_for_DS_Unity_Arabic");*/
        }
    }
}