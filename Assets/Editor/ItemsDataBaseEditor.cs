using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof (ItemsDataBaseScript))]

public class ItemsDataBaseEditor : Editor {
	public enum test{};
	test tt;
	public override void OnInspectorGUI () {
		ItemsDataBaseScript myScript = (ItemsDataBaseScript)target;
		EditorGUILayout.HelpBox("New Item", MessageType.None);
		myScript.itemType = (ItemsDataBaseScript.typeOfItem)EditorGUILayout.EnumPopup("Item type", myScript.itemType);





		if (GUILayout.Button("Create New Object")) {
			myScript.CreateNewObject();
		}


		EditorGUILayout.HelpBox("Item Data Base", MessageType.None);
	}
}
