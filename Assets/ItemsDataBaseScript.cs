using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemsDataBaseScript : MonoBehaviour {

	public enum typeOfItem {Materials = 0, Equipment = 1};
	public enum allMaterials {Metal, Organic, Crystal};




	public typeOfItem itemType;
	public Texture2D icon;
	public string itemName;
	public allMaterials materialType;


	public List<Items> materials = new List<Items>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateNewObject() {
		if (itemType == 0) {
			materials.Add(new Items((int)itemType, icon, itemName, (int)materialType));

		}
		else {

		}


		// Ресет всего
		icon = null;
		itemName = null;
		materialType = 0;
	}
}
