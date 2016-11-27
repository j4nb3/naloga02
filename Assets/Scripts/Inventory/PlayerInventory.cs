using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    private List<Item> items;
    private int itemsMax;
    private bool itemsChanged;

	// Use this for initialization
	void Start () {
        items = new List<Item>();
        itemsMax = 9;
        itemsChanged = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addItem(Item item) {
        if (items.Count < itemsMax) {
            items.Add(item);
            print("Added item " + item);
            itemsChanged = true;
            print(items.Count + " items in inventory.");
        }
        else
            print("Inventory full.");
    }

    public Item getItem(int index) {
        return items[index];
    }

    public int itemCount() {
        return items.Count;
    }

    public bool getItemsChanged() {
        return itemsChanged;
    }

    public void clearItemsChanged() {
        itemsChanged = false;
    }
}
