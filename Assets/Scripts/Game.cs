using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using System.IO;

public class Game : MonoBehaviour {

	public Maze mazePrefab;
    public Grid grid;

	private Maze mazeInstance;

	private void Start () {
		BeginGame();
	}

	private void Update () {
	}

	private void BeginGame () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.Generate();
        grid.CreateGrid();
	}

	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}
}