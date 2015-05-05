using UnityEngine;

public class Item : MonoBehaviour{
	// название вещи
	public string itemName;
	// текстура для инвентаря
	public Texture2D inventoryTexture;
	// префаб для сброса вещи
	public GameObject prefabToDrop;
	// префаб для одевания
	public GameObject prefabToEquip;
}
// элемент инвентаря
/*public class InventoryItem{
	public string name;
	public Texture2D icon;
	public int id;
	public ItemType _ItemType;
	public enum ItemType{
		Weapon,
		Quest,
		Reagents
	}
}*/


// элемент инвентаря