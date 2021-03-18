using UnityEngine;


//greift auf die Inventarlist zu, steuert Anzeige der Hotbar über Eingabe des Nutzers über Mausrad und Zahlen 0-9
public class ItemSwitching : MonoBehaviour
{
    //spiegelt das aktuelle ausgewählte Item wieder, 0= keins ausgewählt, 1 - 10 sind ausgewählte Items
    // ACHTUNG!! hier andere Zählung als im Inventory, dort von 0-9 und -1 = keins ausgewählt
    public int selectedItem = 0;

    void Update()
    {
        //speichert, ob im Tick etwas geändert wurde
        //bool change = false;

        //speichert wie viele Items sich aktuell im Inventar befinden
        int invSize = Inventory.instance.itemList.Count;

        //speichert aktuelle ausgewähltes Item
        int previousSelectedItem = selectedItem;


        #region Mausrad und Zahlen input
        //Mausrad Steuerung
        if (invSize >= 1) //erst wenn es mindestens ein Item im Inventar ist, macht es Sinn zu scrollen
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)        //Mausrad nach oben
            {
                if (selectedItem >= invSize)
                    selectedItem = 1;
                else
                    selectedItem++;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)   //Mausrad nach unten
            {
                if (selectedItem <= 1)
                    selectedItem = invSize;
                else
                    selectedItem--;
            }
        }

        //Keyboard 0-9 Steuerung
        if (Input.GetKeyDown(KeyCode.Alpha1) && invSize >= 1)
            selectedItem = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2) && invSize >= 2)
            selectedItem = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3) && invSize >= 3)
            selectedItem = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha4) && invSize >= 4)
            selectedItem = 4;
        else if (Input.GetKeyDown(KeyCode.Alpha5) && invSize >= 5)
            selectedItem = 5;
        else if (Input.GetKeyDown(KeyCode.Alpha6) && invSize >= 6)
            selectedItem = 6;
        else if (Input.GetKeyDown(KeyCode.Alpha7) && invSize >= 7)
            selectedItem = 7;
        else if (Input.GetKeyDown(KeyCode.Alpha8) && invSize >= 8)
            selectedItem = 8;
        else if (Input.GetKeyDown(KeyCode.Alpha9) && invSize >= 9)
            selectedItem = 9;
        else if (Input.GetKeyDown(KeyCode.Alpha0) && invSize >= 10)
            selectedItem = 10;
        #endregion


        //Abfrage, ob rechte Maustaste gedrückt wird und ruft Use() auf
        //sollte ausgelagert werden
        if (Inventory.instance.itemList.Count > 0)
        {
            if (Input.GetMouseButtonDown(1))
                Inventory.instance.getSelectedItemObject().GetComponent<ItemBehaviour>().Use(true);
            else if (Input.GetMouseButtonUp(1))
                Inventory.instance.getSelectedItemObject().GetComponent<ItemBehaviour>().Use(false);
        }

        //überprüft, ob Itemauswahl höher ist, als es eigentlich Items gibt
        if(selectedItem > invSize)
            selectedItem--;
        //überprüft, ob selectedItem noch 0 ist, aber ein Item hinzugefügt wurde und setzt selectedItem auf 1
        else if (selectedItem == 0 && invSize >= 1)
            selectedItem++;
        
        //Aktuallisert Rahmen
        SelectItem();
    }


    //iteriert durch alle Rahmen durch und deaktiviert/aktiviert den, auf dem das selectende Item ist
    //außerdem setzt es beim aktuellen Item die Variable "isSelected" auf true, um sicherzugehen, dass man in der Hand nur ein Item sieht
    void SelectItem(){

        //Speichert aktuell ausgewähltes Item im Inventar
        Inventory.instance.selectedItem = selectedItem-1;

        //geht durch alle Rahmen und items durch um diese zu aktivieren/isSelected zu setzen
        for (int i = 0; i < 10; i++)
        {
            if (i == selectedItem-1){
                transform.GetChild(selectedItem-1).GetChild(1).gameObject.SetActive(true);
                Inventory.instance.itemList[i].GetComponent<ItemBehaviour>().isSelected = true;
            }
            else
            {
                transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                if(i < Inventory.instance.itemList.Count)
                    Inventory.instance.itemList[i].GetComponent<ItemBehaviour>().isSelected = false;
            }
        }
    }
}
