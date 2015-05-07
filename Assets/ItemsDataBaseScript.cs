using UnityEngine;
using System.Collections;

public class ItemsDataBaseScript : MonoBehaviour {

	public enum typeOfItem {Materials = 0, Equipment = 1};
	public enum allMaterials {Metal, Organic, Crystal};

	public typeOfItem itemType;
	public Texture2D icon;
	public string itemName;
	public allMaterials materialType;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateNewObject() {

	}
}
