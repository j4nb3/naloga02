using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    private List<Item> items;

	// Use this for initialization
	void Start () {
        items = new List<Item>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addItem(Item item) {
        items.Add(item);
        print(items.Count + " items in inventory.");
    }

    public Item getItem(int index) {
        return items[index];
    }

    public int itemCount() {
        return items.Count;
    }
}
