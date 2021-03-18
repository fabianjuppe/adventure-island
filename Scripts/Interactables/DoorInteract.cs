
using UnityEngine;

public class DoorInteract : Interactable
{
	//item mit dem interagiert werden kann
	public ItemData key;

	public override void Interact(bool pressed)
	{
		//ruft BaseMethode Interact von Klasse "Interactable" auf
		base.Interact(pressed);
		if (pressed)
		{
			if (key == null)
			{
				Debug.LogError("kein Key im Inspector vergeben!");
				return;
			}
			//DebugLog mit benötigtetem Key
			Debug.Log("DOOR INTERACT, KEY " + key.itemName + " needed");

			//Überprüfung, ob Key Item gleich dem SelectedItem ist
			if (key == Inventory.instance.getSelectedItemObject().GetComponent<ItemBehaviour>().itemData)
			{
				//entfernt Item, falls es nur einmal nutzbar ist
				Inventory.instance.getSelectedItemObject().GetComponent<ItemBehaviour>().RemoveFromInventory();
				//entfernt das interactable object
				Destroy(gameObject);
			}
		}

	}
}

