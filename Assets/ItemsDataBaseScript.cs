using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class ItemsDataBaseScript : MonoBehaviour {

	public enum typeOfItem {Materials = 0, Equipment = 1};
	public enum allMaterials {Metal, Organic, Crystal};




	public typeOfItem itemType;
	public Texture2D icon;
	public string itemName;
	public allMaterials materialType;


	public List<Items> materials = new List<Items>();

	private GameObject ItemObject;

	string prefabPath = "Assets/Prefabs/Items/Materials/";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateNewObject() {
		if (itemType == 0) {
			// Создание объекта в кэш
			//materials.Add(new Items((int)itemType, icon, itemName, (int)materialType));
			ItemObject = new GameObject(itemName);
			ItemObject.AddComponent<SpriteRenderer>();
			ItemObject.AddComponent<CircleCollider2D>();
			ItemObject.AddComponent<Rigidbody2D>();


			// Создание префаба
			PrefabUtility.CreatePrefab(prefabPath + itemName + ".prefab", ItemObject);

			// Очистка кэша
			DestroyImmediate(ItemObject);
		}
		else {

		}


		// Ресет всего
		icon = null;
		itemName = null;
		materialType = 0;
	}
}
