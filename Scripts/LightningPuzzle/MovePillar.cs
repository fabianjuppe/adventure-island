using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Anfügen einer Sphäre und Bewegen der Säule.
/// </summary>
public class MovePillar : Interactable
{
    /// <summary>
    /// Animator der Säule.
    /// </summary>
    public Animator pillarAnimator;

    /// <summary>
    /// Überprüft, ob die Säule bewegt wurde.
    /// </summary>
    public bool isMoved = false;

    /// <summary>
    /// ItemData der Sphäre.
    /// </summary>
    public ItemData sphere;

    /// <summary>
    /// Audio der Säulenbewegung.
    /// </summary>
    public AudioSource pillarAudio;

    public override void Interact(bool pressed)
    {
        if (pressed)
        {
            if (Inventory.instance.getSelectedItemObject() && sphere == Inventory.instance.getSelectedItemObject().GetComponent<ItemBehaviour>().itemData && transform.childCount < 5) // Ausführen, falls ein Item ausgewählt ist, dieses Item die passende Sphäre ist und sich noch keine Sphäre an der Säule befindet.
            {
                // Sphäre vom Spieler entfernen und als Child an die Säule anhängen.
                GameObject sphereLightning = Inventory.instance.getSelectedItemObject();
                sphereLightning.transform.SetParent(this.transform);
                sphereLightning.GetComponent<ItemBehaviour>().RemoveFromInventory();
                sphereLightning.transform.GetComponent<MeshRenderer>().enabled = true;
                sphereLightning.transform.GetChild(0).gameObject.SetActive(true);
                sphereLightning.transform.localPosition = new Vector3(0.0f, 4.0f, 0.0f);
                sphereLightning.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                sphereLightning.transform.rotation = transform.rotation;
            }
            else //Bewegen der Säule und Abspielen des Audios.
            {
                isMoved = !isMoved;
                pillarAnimator.SetBool("isMoved", isMoved);
                pillarAudio.Play();
            }   
        }
    }
}

