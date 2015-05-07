using UnityEngine;
using System.Collections;

public class ItemsDataBaseScript : MonoBehaviour {

	public enum typeOfItem {Materials, Equpment};
	public enum allTypes {Metal, Organic, Crystal};

	public typeOfItem itemType;
	public Texture2D icon;
	public string itemName;
	public allTypes type;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateNewObject() {

	}
}
