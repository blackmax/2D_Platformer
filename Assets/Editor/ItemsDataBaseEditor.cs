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
		myScript.itemName = EditorGUILayout.TextField("Item name", myScript.itemName);
		myScript.icon = (Texture2D) EditorGUILayout.ObjectField("Image", myScript.icon, typeof (Texture2D), false);

		if (myScript.itemType == 0) {
			myScript.materialType = (ItemsDataBaseScript.allMaterials)EditorGUILayout.EnumPopup("Material type", myScript.materialType);
		}
		else {
			myScript.itemName = EditorGUILayout.TextField("cheto", myScript.itemName);
		}





		if (GUILayout.Button("Create New Object")) {
			myScript.CreateNewObject();
		}


		EditorGUILayout.HelpBox("Item Data Base", MessageType.None);
	}
}
