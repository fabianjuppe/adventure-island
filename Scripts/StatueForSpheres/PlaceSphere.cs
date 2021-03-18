using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ablegen einer Sphäre.
/// </summary>
public class PlaceSphere : Interactable
{
    /// <summary>
    /// ItemData der Sphäre.
    /// </summary>
    public ItemData sphere;

    public override void Interact(bool pressed)
    {
        if (pressed)
            if (Inventory.instance.getSelectedItemObject() && sphere == Inventory.instance.getSelectedItemObject().GetComponent<ItemBehaviour>().itemData) // Ausführen, falls ein Item ausgewählt ist und dieses Item die passende Sphäre ist.
            {
                // Sphäre vom Spieler entfernen und als Child an die Schale anhängen.
                GameObject sphereTemp = Inventory.instance.getSelectedItemObject();
                sphereTemp.transform.SetParent(this.transform);
                sphereTemp.GetComponent<ItemBehaviour>().RemoveFromInventory();
                sphereTemp.transform.GetComponent<MeshRenderer>().enabled = true;
                sphereTemp.transform.GetChild(0).gameObject.SetActive(true);
                sphereTemp.transform.localPosition = new Vector3(0.0f, 0.0f, -0.5f);
                sphereTemp.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
    }
}
