using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerRaycasting : MonoBehaviour
{
    /// <summary>
    /// Länge des Raycasts
    /// </summary>
    public float distanceToSee;

    /// <summary>
    /// Text Objekt, auf dem der Text angezeigt werden soll, wenn ein Objekt getroffen wird, dass von <Interact> geerbt hat
    /// </summary>
    public GameObject text;
    /// <summary>
    /// Standart Text, falls kein andere Text in einer Kindklasse von <Interact> angegeben ist
    /// </summary>
    public string defaultText;

    public Image crosshair; 
    public Color defaultCrosshairColor;
    public Color interactCrosshairColor;

    /// <summary>
    /// speichert den letzen RaycastHit
    /// </summary>
    private RaycastHit whatIHitLast;


    /// <summary>
    /// nutzt Unitys <Raycast> Klasse, um von der Mitte der Kamera nach vorne abzutasten
    /// Falls getroffenes Objekt von <Interactable> erbt und Interaktionstaste gedrückt wird, wird im getroffenen Objekt <Interact()> aufgerufen
    /// </summary>
    void Update()
    {
        // macht den Ray im Editor sichtbar
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        // überprüft, ob zuletzt ein Objekt getroffen wurde und
        // das letzte ungleich dem aktuellen ist und 
        // das letzte getroffene von <Interactable> erbt,
        // falls das alles zutrifft wird <Interact(false)> aufgerufen, der Text deaktiviert und das Crosshair standart gefärbt
        if (whatIHitLast.collider != null && whatIHitLast.collider != GameManager.Instance.whatIHit.collider && whatIHitLast.collider.gameObject.GetComponent<Interactable>())
        {
            whatIHitLast.collider.GetComponent<Interactable>().Interact(false);
            text.SetActive(false);
            crosshair.color = defaultCrosshairColor;
        }


        // in der If anweisung passiert der Raycast und das Ergebnis wird in den Game Manager geschrieben
        if (Physics.Raycast(this.transform.position, this.transform.forward, out GameManager.Instance.whatIHit, distanceToSee))
        {
 
            // neuer Hit wird in whatIHitLast geschrieben, um es im nächsten Update() durchlauf zu verwenden
            whatIHitLast = GameManager.Instance.whatIHit;

            //überprüft, ob getroffenes Objekt von Interactable geerbt hat
            if (GameManager.Instance.whatIHit.collider.gameObject.GetComponent<Interactable>())
            {
                Debug.Log("I Hit " + GameManager.Instance.whatIHit.transform.gameObject.name);
                //wenn E oder F gedrückt wird, dann wird Interact(true) ausgeführt
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("E pressed");
                    GameManager.Instance.whatIHit.collider.GetComponent<Interactable>().Interact(true);
                }
                //wenn E oder F losgelassen wird, dann wird Interact(false) aufgerufen
                else if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.F))
                    GameManager.Instance.whatIHit.collider.GetComponent<Interactable>().Interact(false);


                //Falls in im Interactable Script kein Text übergeben wurde, dann wird defaultText angezeigt
                if (GameManager.Instance.whatIHit.collider.GetComponent<Interactable>().displayText == "")
                {
                    text.GetComponent<Text>().text = defaultText;
                }
                else
                {
                    text.GetComponent<Text>().text = GameManager.Instance.whatIHit.collider.GetComponent<Interactable>().displayText;
                }

                //Falls im Interactable Script eine custom CrosshairColor angegeben wurde, dann wird die verwendet
                if (GameManager.Instance.whatIHit.collider.GetComponent<Interactable>().useCrosshairColor == true)
                {
                    crosshair.color = GameManager.Instance.whatIHit.collider.GetComponent<Interactable>().crosshairColor;
                }
                else
                {
                    crosshair.color = interactCrosshairColor;
                }

                text.SetActive(true);
            }
        }
        //falls das getroffene Objekt nicht von Interactable erbt, dann wird kein Text angezeigt und die CrosshairColor wird auf default gesetzt
        else
        {
            text.SetActive(false);
            crosshair.color = defaultCrosshairColor;
        }
    }
}
