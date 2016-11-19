using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryDisplay : MonoBehaviour {

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;

    private PlayerInventory playerInventory;
    private Button[] buttons;

    // Use this for initialization
    void Start () {
        playerInventory = firstPersonController.GetComponent<PlayerInventory>();
        buttons = GetComponentsInChildren<Button>();     
    }
	
	// Update is called once per frame
	void Update () {
        if (playerInventory.getItemsChanged()) {
            for (int i = 0; i < playerInventory.itemCount(); i++) {
                buttons[i].GetComponentInChildren<Text>().text = playerInventory.getItem(i).itemName;
                print(playerInventory.getItem(i).itemName);
            }

            playerInventory.clearItemsChanged();
        }
    }
}
