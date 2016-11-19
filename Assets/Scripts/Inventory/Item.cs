using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public int itemID;
    public string itemName;
    public string itemDesc;  
    public Texture2D itemIcon;

    /*public string ItemName {
        get { return itemName; }
        set { itemName = value; }
    }*/

    void OnTriggerEnter(Collider other) {
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        inventory.addItem(this);
        Destroy(gameObject);
    }
}
