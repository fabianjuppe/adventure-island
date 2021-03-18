using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// stellt den Kern des Inventars da, beinhaltet die Liste mit den GameObjects die gerade im Inventar sind
// Zugriff auf der Inventar bekommt man mit "Inventory.instance" (siehe Singelton unten)


public class Inventory : MonoBehaviour
{

	//stellt sehr vereinfacht ein Singelton dar, damit man von überall aus auf das Inventar über "Inventory.instance" zugreifen kann
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
		if(instance != null){
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}
        instance = this;
    }

	#endregion

	//erstellt ein "Observer"
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	//legt den Platz für das Inventar fest, sollte sich aber nicht ändern im gesamten Spiel
	public int space = 10;

	//gibt den Index an, welches Item aus der ItemList gerade in der Hand ist, der Wert "-1" bedeutet es ist kein Item ausgewählt
	public int selectedItem;

	public List<GameObject> itemList = new List<GameObject>();
 


	// Item hinzufuegen wenn ein Inventar Slot frei ist.
	public void AddItem(GameObject item)
	{
		if (itemList.Count >= space)
		{
			Debug.Log("Not enough room.");
			return;
		}
		itemList.Add(item);

		//ruft alle angemeldeten Funktionen auf, zB in InventoryUI die UpdateUI()
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	// Item aus Inventar entfernen
	public void Remove(GameObject item)
	{
		itemList.Remove(item);
		//ruft alle angemeldeten Funktionen auf, zB in InventoryUI die UpdateUI()
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	//gibt das GameObejekt zurück, das aktuell ausgewählt ist, könnte zu Fehlern kommen, wenn "null" zurückgegeben wird
	public GameObject getSelectedItemObject(){
		Debug.Log("Selected Item: "+selectedItem);
		if(selectedItem > -1 && itemList.Count > 0)
			return itemList[selectedItem];
		else 
			return null;
	}
}
