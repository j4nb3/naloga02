using UnityEngine;
using System.Collections;
using System.Collections.Generic; 


public class Maze : MonoBehaviour {

	public MazeCell cellPrefab;
	public MazeWall wallPrefab;

	private MazeCell[,] cells;
	private MazeWall[,] walls;

	private int[,] grid;

	public float generationStepDelay;

	public IntVector2 size;

	private bool isValid(int tx, int ty){
		if((-1<tx)&&(tx<size.x)&&(ty<size.z)&&(-1<ty)){
			return true;
		}
		else{
			return false;
		}

	}

	private List<int[]> frontierCells(int[,] grid, int[] vertex){
		List<int[]> rtn = new List<int[]> ();
		int x = vertex [0];
		int y = vertex [1];
		if (isValid (x-2, y) && grid[x-2,y] == 1) {
			rtn.Add (new int[2] {x-2, y});
		}
		if (isValid (x+2, y) && grid[x+2,y] == 1) {
			rtn.Add (new int[2] {x+2, y});
		}
		if (isValid (x, y-2) && grid[x,y-2] == 1) {
			rtn.Add (new int[2] {x, y-2});
		}
		if (isValid (x, y+2) && grid[x,y+2] == 1) {
			rtn.Add (new int[2] {x, y+2});
		}
		print (rtn.Count);
		return rtn;
	}
	private List<int[]> neighborCells(int[,] grid, int[] vertex){
		List<int[]> rtn = new List<int[]> ();
		int x = vertex [0];
		int y = vertex [1];
		if (isValid (x-2, y) && grid[x-2,y] == 1) {
			rtn.Add (new int[2] {x-2, y});
		}
		if (isValid (x+2, y) && grid[x+2,y] == 1) {
			rtn.Add (new int[2] {x+2, y});
		}
		if (isValid (x, y-2) && grid[x,y-2] == 1) {
			rtn.Add (new int[2] {x, y-2});
		}
		if (isValid (x, y+2) && grid[x,y+2] == 1) {
			rtn.Add (new int[2] {x, y+2});
		}
		print (rtn.Count);
		return rtn;
	}
	//http://stackoverflow.com/questions/29739751/implementing-a-randomly-generated-maze-using-prims-algorithm Implementation
	private void PrimsMaze(){
		List<int[]> V = new List<int[]> ();
		grid = new int[size.x, size.z];
		for (int i1 = 0; i1 <  size.x; i1++) {
			for (int i2 = 0; i2 < size.z; i2++) {
				grid [i1, i2] = 1;
			}
		}
		V.Add(new int[2]{UnityEngine.Random.Range (0, size.x), UnityEngine.Random.Range (0, size.z)});
		grid [V [0] [0], V [0] [1]] = 0;
		V.AddRange (frontierCells (grid, V [0]));
		V.RemoveAt (0);
		while (V.Count > 0) {
			print (V.Count);
			int[] vertex = V[UnityEngine.Random.Range(0,V.Count-1)];
			List<int[]> neigbours = neighborCells (grid, vertex);
			if (neigbours.Count > 0) {
				int[] random = neigbours [UnityEngine.Random.Range (0, neigbours.Count - 1)];
				grid [random [0], random [1]] = 0;
				grid [(vertex [0] + random [0]) / 2, (vertex [1] + random [1]) / 2] = 0;
				V.AddRange(frontierCells(grid,vertex));
			}
			V.Remove(vertex);

		}
	}
	public void Generate () {
		cells = new MazeCell[size.x, size.z];
		walls = new MazeWall[size.x, size.z];
		grid = new int[size.x, size.z];
		for (int i1 = 0; i1 < size.x; i1++) {
			for (int i2 = 0; i2 <  size.z; i2++) {
				grid [i1, i2] = 1;
			}
		}
		PrimsMaze ();
		for (int x = 0; x < size.x; x++) {
			for (int z = 0; z < size.z; z++) {
				if(grid[x,z]==0){
					CreateCell(new IntVector2(x, z));
				}
				if(grid[x,z]==1){
					if (size.z != z) {
						CreateWall (new IntVector2 (x, z)); 
					}
				}	

			}
		}
	}

	private void CreateCell (IntVector2 coordinates) {
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition =
			new Vector3(coordinates.x - size.x * 0.5f , 0f, coordinates.z - size.z * 0.5f );
	}
	private void CreateWall (IntVector2 coordinates) {
		MazeWall newWall = Instantiate(wallPrefab) as MazeWall;
		walls[coordinates.x, coordinates.z] = newWall;
		newWall.coordinates = coordinates;
		newWall.name = "Maze Wall " + coordinates.x + ", " + coordinates.z;
		newWall.transform.parent = transform;
		newWall.transform.localPosition =
			new Vector3(coordinates.x - size.x * 0.5f , 0.5f, coordinates.z - size.z * 0.5f );
	}


}