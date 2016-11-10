using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject inventory;

    private Rigidbody rb;
    private bool isPaused;
    private GameObject[] pauseMenuChildren;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        isPaused = false;
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
            Destroy(other.gameObject);
        }
    }
}
