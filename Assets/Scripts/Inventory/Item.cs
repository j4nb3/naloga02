using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string itemName;
    public int itemID;
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
