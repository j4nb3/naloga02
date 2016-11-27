using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public int itemID;
    public string itemName;
    public string itemDescription;
    public Texture2D itemIcon;

    void OnTriggerEnter(Collider other) {
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        inventory.addItem(this);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
