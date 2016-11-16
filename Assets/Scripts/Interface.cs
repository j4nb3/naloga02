using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	public GameObject inventoryMenu;

	private Inventory inventory;
	// Use this for initialization
	void Start () {
	    inventory = inventoryMenu.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            Item item = other.GetComponent<Item>();
            print(item.itemName);
            if (inventory.AddItem(item)){
                Destroy(item.gameObject);
            }
        }
    }
}
