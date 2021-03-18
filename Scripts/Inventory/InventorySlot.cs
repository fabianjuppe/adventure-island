using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Wird den UI Elementen zugewiesen, die das Icon des Items anzeigen soll.

public class InventorySlot : MonoBehaviour
{
	GameObject itemObject; 	// Item was in diesem InventorySlot aktuell drin ist
	public Image icon;		// icon was angzeigt werden soll

	// Setzt Icons von Item in die UI
	public void AddItemObject(GameObject newItem)
	{
		itemObject = newItem;

		icon.sprite = itemObject.GetComponent<ItemBehaviour>().itemData.icon;
		icon.enabled = true;
	}

	// Setzt den InventorySlot zurück, kein Icon mehr
	public void ClearSlot()
	{
		itemObject = null;

		icon.sprite = null;
		icon.enabled = false;
	}
}
