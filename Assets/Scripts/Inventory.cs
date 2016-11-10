using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private List<Item> items;
    private int inventorySize;
    private Button[] buttons;

    public Inventory() {
        items = new List<Item>();      
        inventorySize = 9;
    }

    public Inventory(int size) {
        items = new List<Item>();
        inventorySize = size;
    }

	// Use this for initialization
	void Awake () {
        buttons = GetComponentsInChildren<Button>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public bool AddItem(Item item) {
        if (items.Count < inventorySize) {
            if (item != null) {
                items.Add(item);
                buttons[items.Count - 1].GetComponentInChildren<Text>().text = item.itemName;
                return true;
            }
            else
                return false;
        }
        else {
            return false;
        }
    }
}
