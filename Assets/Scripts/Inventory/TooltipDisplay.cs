using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TooltipDisplay : MonoBehaviour {

    public Tooltip tooltip;

    private ItemSlot slot;

    // Use this for initialization
    void Start() {
        slot = GetComponent<ItemSlot>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void showTooltip() {
        if (slot.item != null) {
            tooltip.setText(slot.item.itemName, slot.item.itemDescription);
            tooltip.transform.position = Input.mousePosition;
            tooltip.transform.localScale = new Vector3(1, 1, 1);
            tooltip.gameObject.SetActive(true);               
        }
        else {
            tooltip.transform.localScale = new Vector3(0, 0, 0);
            tooltip.gameObject.SetActive(true);
        }
    }

    public void hideTooltip() {
        tooltip.gameObject.SetActive(false);
    }
}
