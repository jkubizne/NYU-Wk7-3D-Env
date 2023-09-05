using UnityEngine;
using System.Collections;
using UnityEditor;
[InitializeOnLoad]
public class MyHierarchyPanel
{
    static MyHierarchyPanel()
    {
        EditorApplication.hierarchyWindowItemOnGUI += hierarchWindowOnGUI;

    }
    static void hierarchWindowOnGUI(int instanceID, Rect selectionRect)
    {
        //change bg and font color
        GUI.backgroundColor = Color.magenta;
        GUI.contentColor = Color.white;

        // get objects
        Object o = EditorUtility.InstanceIDToObject(instanceID);
        GameObject g = (GameObject)o as GameObject;
    }

}