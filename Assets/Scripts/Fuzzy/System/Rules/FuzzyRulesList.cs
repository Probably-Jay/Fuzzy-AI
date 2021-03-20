using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

using UnityEditor;
using UnityEditorInternal;

#endif

namespace FuzzyLogic
{
    [CreateAssetMenu(menuName = "Rules/Fuzzy Rules")]
    public class FuzzyRulesList : ScriptableObject
    {

        public SimpleFuzzyRule[] rules;
    }

    [System.Serializable]
    public class SimpleFuzzyRule
    {
    
   

        //public enum Logic
        //{
        //    And
        //    , Or
        //}


        public CrispInput.Inputs input;
        public FuzzyUtility.FuzzyStates inputState;

        public CrispOutput.Outputs output;
        public FuzzyUtility.FuzzyStates outputState;

     //   public Logic logicalRelationships;


    } 
    
    //[System.Serializable]
    //internal class LogicalFuzzyRule
    //{



    //    public enum Logic
    //    {
    //        And
    //        , Or
    //    }


    //    public CrispInput.Inputs input;
    //    public FuzzyNumber.FuzzyStates inputState;

    //    public CrispOutput.Outputs output;
    //    public FuzzyNumber.FuzzyStates outputState;

    // //   public Logic logicalRelationships;


    //}



#if UNITY_EDITOR

    [CustomEditor(typeof(FuzzyRulesList))]
    public class FuzzyRulesEditor : Editor
    {


        SerializedProperty rules;

        ReorderableList list;

        private void OnEnable()
        {
            rules = serializedObject.FindProperty(nameof(FuzzyRulesList.rules));

            list = new ReorderableList(serializedObject, rules, true, true, true, true);

            list.drawElementCallback = DrawListItems; 
            list.drawHeaderCallback = DrawHeader; 
        }


        public override void OnInspectorGUI()
        {

          //  base.OnInspectorGUI();

            serializedObject.Update(); 

            list.DoLayoutList(); 

          
            serializedObject.ApplyModifiedProperties();

        }


        void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);

            EditorGUI.LabelField(new Rect(rect.x, rect.y, 15, EditorGUIUtility.singleLineHeight), "If");

            EditorGUI.PropertyField(
                 new Rect(rect.x+15, rect.y, 110, EditorGUIUtility.singleLineHeight),
                 element.FindPropertyRelative(nameof(SimpleFuzzyRule.input)),
                 GUIContent.none
                ); 
            
            EditorGUI.PropertyField(
                 new Rect(rect.x+125, rect.y, 35, EditorGUIUtility.singleLineHeight),
                 element.FindPropertyRelative(nameof(SimpleFuzzyRule.inputState)),
                 GUIContent.none
                );

            EditorGUI.LabelField(new Rect(rect.x+165, rect.y, 30, EditorGUIUtility.singleLineHeight), "then");


            EditorGUI.PropertyField(
                 new Rect(rect.x + 200, rect.y, 100, EditorGUIUtility.singleLineHeight),
                 element.FindPropertyRelative(nameof(SimpleFuzzyRule.output)),
                 GUIContent.none
                );

            EditorGUI.PropertyField(
                 new Rect(rect.x +300, rect.y, 40, EditorGUIUtility.singleLineHeight),
                 element.FindPropertyRelative(nameof(SimpleFuzzyRule.outputState)),
                 GUIContent.none
                );

            //EditorGUI.PropertyField(
            //    new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight),
            //    element.FindPropertyRelative("mobs"),
            //    GUIContent.none
            //);




            //EditorGUI.PropertyField(
            //    new Rect(rect.x, rect.y, 20, EditorGUIUtility.singleLineHeight),
            //    element.FindPropertyRelative("level"),
            //    GUIContent.none
            //);


          //  EditorGUI.LabelField(new Rect(rect.x + 200, rect.y, 100, EditorGUIUtility.singleLineHeight), "Quantity");

         
            //EditorGUI.PropertyField(
            //    new Rect(rect.x, rect.y, 20, EditorGUIUtility.singleLineHeight),
            //    element.FindPropertyRelative("quantity"),
            //    GUIContent.none
            //);

        }


        void DrawHeader(Rect rect)
        {
            string name = "Rules";
            EditorGUI.LabelField(rect, name);
        }


    }


#endif
}