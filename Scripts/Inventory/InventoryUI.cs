using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public Transform itemsParent;   // Die Oberklasse aller ItemSlot UI Elemente

	Inventory inventory;    // Unser derzeitiges Inventar

	InventorySlot[] slots;	//Array mit allen InventorySlots

	void Start()
	{
		//setzt inventory auf unsere Inventory Instance
		inventory = Inventory.instance;
		//schreibt sich in die "onItemChangedCallback" von inventory ein -> wenn OnItemChangedCallback aufgerufen wird, wird hier UpdateUI() aufgerufen
		inventory.onItemChangedCallback += UpdateUI;
		//slots wird gefüllt mit allen InventorySlots
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	//updatet das UI entsprechend dem aktuellen Zustand des Inventares und der Items
	public void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.itemList.Count)
				slots[i].AddItemObject(inventory.itemList[i]);
			else
				slots[i].ClearSlot();
		}
	}
}
