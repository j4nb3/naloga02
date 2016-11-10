using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject inventoryMenu;

    private Rigidbody rb;
    private bool isPaused;
    private Inventory inventory;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        inventory = inventoryMenu.GetComponent<Inventory>();
        isPaused = false;

        //inventory = new Inventory();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0.0f;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused) {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1.0f;
        }
	}

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * 10);
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
