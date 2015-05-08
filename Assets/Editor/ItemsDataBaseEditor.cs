using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;


[CustomEditor(typeof (ItemsDataBaseScript))]

public class ItemsDataBaseEditor : Editor {
	string prefabPath = "Assets/Prefabs/Items/Materials/";

	public override void OnInspectorGUI () {
		ItemsDataBaseScript myScript = (ItemsDataBaseScript)target;

		EditorGUILayout.LabelField("----New Item----");
		myScript.itemType = (ItemsDataBaseScript.typeOfItem)EditorGUILayout.EnumPopup("Item type", myScript.itemType);
		myScript.itemName = EditorGUILayout.TextField("Item name", myScript.itemName);
		myScript.icon = (Texture2D) EditorGUILayout.ObjectField("Image", myScript.icon, typeof (Texture2D), false);

		if (myScript.itemType == 0) {
			myScript.materialType = (ItemsDataBaseScript.allMaterials)EditorGUILayout.EnumPopup("Material type", myScript.materialType);
		}
		else {
			myScript.itemName = EditorGUILayout.TextField("cheto", myScript.itemName);
		}



		EditorGUILayout.Space();
		if (GUILayout.Button("Create New Object")) {
			myScript.CreateNewObject();
		}

		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("----Item Data Base----");
		EditorGUILayout.Space();

		DirectoryInfo dir = new DirectoryInfo("Assets/Prefabs/Items/Materials");
		FileInfo[] prefabs = dir.GetFiles("*.prefab");
		foreach (FileInfo prefab in prefabs) 
		{ 
			EditorGUILayout.LabelField("" + prefab.Name.Substring(0, prefab.Name.Length - 7));
		}


	}
}
