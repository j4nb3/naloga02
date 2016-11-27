using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryDisplay : MonoBehaviour {

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;

    private PlayerInventory playerInventory;
    private ItemSlot[] slots;

    // Use this for initialization
    void Start () {
        playerInventory = firstPersonController.GetComponent<PlayerInventory>();
        slots = GetComponentsInChildren<ItemSlot>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerInventory.getItemsChanged()) {
            for (int i = 0; i < playerInventory.itemCount(); i++) {
                slots[i].item = playerInventory.getItem(i);
            }

            playerInventory.clearItemsChanged();
        }
    }
}
