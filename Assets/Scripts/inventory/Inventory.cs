using System.Collections.Generic;
using UnityEngine;


// инвентарь
public class Inventory : MonoBehaviour
{
	// вещи инвентаря
	public List<Item> items = new List<Item>();
	// надетые вещи
	public List<Item> equipped = new List<Item>();
	// отображать ли инвентарь
	private bool showInventory;
	
	// вспомогательные переменные
	private Vector2 _inventoryScroll;
	private Item _itemToDrop = null;
	private Item _itemToEquip = null;
	
	public void Update()
	{
		// если нужно выбросить вещь
		if(_itemToDrop!=null)
		{
			// удаляем вещь из инвентаря
			items.Remove(_itemToDrop);
			// создаем в сцене эту вещь на месте, где стоит игрок
			Instantiate(_itemToDrop.prefabToDrop, transform.position, transform.rotation);
			_itemToDrop = null;
		}
		
		// если нужно одеть
		if (_itemToEquip != null)
		{
			// удаляем вещь из инвентаря
			items.Remove(_itemToEquip);
			// добавляем ее к одетым вещам
			equipped.Add(_itemToEquip);
			// создаем у игрока эту вещь
			GameObject itemGameObject= (GameObject)Instantiate(_itemToEquip.prefabToEquip);
			// так как игрок одел вещь, то она является его чайлдом
			itemGameObject.transform.parent = transform;
			_itemToEquip = null;
		}
	}
	
	// отображение инвентаря
	public void OnGUI()
	{
		if (showInventory)
		{
			if(GUI.Button(new Rect(10, 10, 150, 25), "Hide Inventory"))
			{
				showInventory = !showInventory;
			}
			
			GUILayout.BeginArea(new Rect(Screen.width-200, 10, 190, Screen.height-20), GUI.skin.box);
			{
				_inventoryScroll = GUILayout.BeginScrollView(_inventoryScroll, GUILayout.ExpandHeight(true),GUILayout.ExpandWidth(true));
				
				// рисуем каждую вещь инвентаря
				foreach (Item item in items)
				{
					GUILayout.BeginVertical(GUI.skin.box);
					GUILayout.Label(item.itemName); // Название
					GUILayout.BeginHorizontal();
					GUILayout.Label(item.inventoryTexture); // Иконка
					GUILayout.BeginVertical();
					if (GUILayout.Button("Equip"))  // Кнопка "надеть"
					{
						_itemToEquip = item;
					}
					if (GUILayout.Button("Drop"))  // Кнопка "бросить"
					{
						_itemToDrop = item;
					}
					GUILayout.EndVertical();
					GUILayout.EndHorizontal();
					GUILayout.EndVertical();
				}
				
				
				GUILayout.EndScrollView();
			}
			GUILayout.EndArea();
			
		}
		
		else
		{
			if (GUI.Button(new Rect(10, 10, 150, 25), "Show Inventory")) 
			{
				showInventory = !showInventory;
			}
		}
	}
	
	
	// подбор вещи
	public void Equip(object item)
	{
		sceneItem sceneItem = (sceneItem) item;
		
		if (sceneItem!= null)
		{
			// добавляем вещь в инвентарь
			items.Add(sceneItem.prefab);
			// уничтожаем объект сцены
			Destroy(sceneItem.gameObject);
		}
		
	}
	
}