using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ablegen des Cauldron.
/// </summary>
public class PlaceCauldron : Interactable
{
    /// <summary>
    /// ItemData des Cauldron.
    /// </summary>
    public ItemData cauldron;
    public GameObject cauldronGameObject;
    public Animator waterSphere, gate;
    public AudioSource gateAudio;

    public override void Interact(bool pressed)
    {
        if (pressed)
            if (Inventory.instance.getSelectedItemObject() && cauldron == Inventory.instance.getSelectedItemObject().GetComponent<ItemBehaviour>().itemData) // Ausführen, falls ein Item ausgewählt ist und dieses Item die passende Sphäre ist.
            {
                // Sphäre vom Spieler entfernen und als Child an die Schale anhängen.
                GameObject cauldronTemp = Inventory.instance.getSelectedItemObject();
                cauldronTemp.transform.SetParent(this.transform);
                cauldronTemp.GetComponent<ItemBehaviour>().RemoveFromInventory();
                cauldronTemp.transform.GetComponent<MeshRenderer>().enabled = true;
                cauldronTemp.transform.localPosition = new Vector3(-0.0003585815f, 0.4742498f, -0.0004272461f);
                cauldronTemp.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                cauldronTemp.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                Destroy(cauldronGameObject.GetComponent<ItemBehaviour>());
                waterSphere.SetBool("IsCooking", true);
                gate.SetBool("hasEntered", false);
                gateAudio.Play();
            }
    }
}
