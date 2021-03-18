using UnityEngine;


//definiert ein GameObject als Item und ermöglicht aufsammeln, erbt von Interactable,
//damit vom Raycast Interact aufgerufen wird
public class ItemBehaviour : Interactable
{
    //speichert das Scritable Object vom Typ ItemData
    public ItemData itemData;
    //speichert den Rigidbody, sofern vorhanden
    private Rigidbody rigidBody;
    // speichert ein Script, das von ItemUsage geerbt hat. 
    private ItemUsage usingScript;
    //speichert eine mögliche Kindkomponente, um diese auszuschalten (hilfreich wenn man Models verwendet)
    public GameObject child;

    //speichert, ob ein Object benutzbar ist, zieht seinen Wert aus ItemData
    private bool isUsable;
    //wird auf true gesetzt, wenn es aktuell in der Hand ist, auf false wenn es nicht in der Hand ist -> wird ausgeblendet
    public bool isSelected;
    //wird auf true gesetzt, sobald man es aufgehoben hat und es im Inventar erscheint
    private bool isInInventory;


    void Start()
    {
        isUsable = itemData.isUsable;
        isInInventory = false;
        isSelected = false;

        //sucht nach den entsprechenden Componenten
        rigidBody = GetComponent<Rigidbody>();
        usingScript = GetComponent<ItemUsage>();

        //Debug Ausgabe
        if(child == null)
            Debug.LogWarning("Es wurde im Inspector von" + itemData.itemName + " kein Kind übergeben");
        if(itemData == null)
            Debug.LogWarning("Es wurde im Inspector von" + itemData.itemName + " kein ItemData übergeben");
        if(usingScript == null)
            Debug.LogWarning("Es konnte kein ItemUsage Script in " + itemData.itemName + " finden");
    }

    // behandelt die Sichtbarkeit des Items in der Hand und im Inventar, behandelt auch den Fall, falls das Item im Inventar ist, aber noch nicht die Position angepasst wurde
    // sollte man in die PickUp() auslagern, macht hier eigentlich keinen Sinn
    private void Update() 
    {
        if(isInInventory)
        {
            if (!transform.GetComponentInParent<Camera>())
            {
                Debug.Log("Item wird an Spieler angefügt!");

                if (itemData.PickUpSound != null)
                {
                    Instantiate(itemData.PickUpSound, transform.position, transform.rotation);
                }

                transform.SetParent(PlayerMovement.instance.GetComponentInChildren<Camera>().GetComponent<Transform>());

                transform.position = PlayerMovement.instance.GetComponentInChildren<Camera>().transform.position;
                transform.localPosition = itemData.transformInHands;

                if(itemData.useScaleInHands == true)
                {
                    float scale = itemData.scaleInHands;
                    transform.localScale = new Vector3(scale, scale, scale);
                }

                if(itemData.useRotatInHands == true)
                    transform.rotation = itemData.quatRotInHands;
                else 
                    transform.rotation = PlayerMovement.instance.GetComponentInChildren<Camera>().transform.rotation;

            }

            if (isSelected)
            {
                if(transform.GetComponent<MeshRenderer>()) 
                    transform.GetComponent<MeshRenderer>().enabled = true;
                if(child) 
                    child.SetActive(true);
            }
            else
            {
                if(transform.GetComponent<MeshRenderer>()) 
                    transform.GetComponent<MeshRenderer>().enabled = false;
                if(child) 
                    child.SetActive(false);
            }
        }
    }

    //wird aufgerufen, wenn man rechte Maustaste drückt
    public void Use(bool clicked)
    {
        if(isUsable)
        {
            Debug.Log("Item "+ itemData.itemName + " wurde genutzt!");
            usingScript.UseItem(clicked);
        }
        else
        {
            Debug.Log("Item kann nicht benutzt werden");
        }
    }

    //wird aufgerufen, wenn man über <PlayerRaycasting> E/F drückt  
    public override void Interact(bool pressed)
    {
        base.Interact(pressed);
        Debug.Log("Itembehaviour Interact ausgeführt!" + itemData.itemName);
        if (itemData.isPickable && pressed) 
            PickUp();
    }

    //behandelt das Aufheben von Items
    void PickUp()
    {
        Debug.Log("Picking "+itemData.itemName+" up!");
        isInInventory = true;
        Destroy(rigidBody);
        Inventory.instance.AddItem(this.gameObject);
    }
    
    //behandelt das entfernen aus dem Inventar
    public void RemoveFromInventory()
    {
        isSelected = false;
        isInInventory = false;

        if (transform.GetComponent<MeshRenderer>())
            transform.GetComponent<MeshRenderer>().enabled = false;
        if (child)
            child.SetActive(false);

        Inventory.instance.Remove(this.gameObject);
    }

}
