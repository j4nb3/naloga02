using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSlot : MonoBehaviour {

    public Item item;
    private Text itemName;

    /*public Item Item {
        get { return item; }
        set { item = value; }
    }*/

	// Use this for initialization
	void Start () {
        itemName = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (item != null) {
            itemName.text = item.itemName;
        }
    }
}
