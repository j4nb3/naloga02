using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class Tuple<T1, T2>
{
	public T1 First { get; private set; }
	public T2 Second { get; private set; }
	internal Tuple(T1 first, T2 second)
	{
		First = first;
		Second = second;
	}
}

public static class Tuple
{
	public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
	{
		var tuple = new Tuple<T1, T2>(first, second);
		return tuple;
	}
}

public class Maze : MonoBehaviour {

	public MazeCell cellPrefab;
	public MazeWall wallPrefab;

	private MazeCell[,] cells;
	private MazeWall[,] walls;
	private MazeWall[,] outerwalls;

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
	private void GenV2(){
		int num_rows = size.x;
		int num_cols = size.z;

		int[, ,] M = new int[num_rows,num_cols,5];

		int r = 0;
		int c = 0;
		List<Tuple<int, int>>history = new List<Tuple<int, int>>();
		history.Add (new Tuple<int, int>(r, c));
		while(history.Count>0){
			M [r, c, 4] = 1;
			List<char> check = new List<char> ();
			if(c > 0 && M[r, c-1, 4]==0){
				check.Add ('L');
			}
			if(r > 0 && M[r-1, c, 4]==0){
				check.Add ('U');
			}
			if(c<num_cols-1 && M[r, c+1, 4] == 0){
				check.Add('R');
			}
			if(r<num_rows-1 && M[r+1, c, 4] == 0){
				check.Add('D');
			}
			if (check.Count > 0) {
				history.Add (new Tuple<int, int>(r, c));
				int rand_n = Random.Range(0, check.Count);
				char move_direction = check [rand_n];
				if(move_direction == 'L'){
					M [r, c, 0] = 1;
					c = c - 1;
					M [r, c, 2] = 1;
				}
				if(move_direction == 'U'){
					M [r, c, 1] = 1;
					r = r - 1;
					M [r, c, 3] = 1;
				}
				if(move_direction == 'R'){
					M [r, c, 2] = 1;
					c = c + 1;
					M [r, c, 0] = 1;
				}
				if(move_direction == 'D'){
					M [r, c, 3] = 1;
					r = r + 1;
					M [r, c, 1] = 1;
				}
			} else {
				Tuple<int, int> new_move = history [history.Count - 1];
				history.RemoveAt (history.Count - 1);
				r = new_move.First;
				c = new_move.Second;
			}

		}
		for(int row=0; row<num_rows; row++){
			for(int col=0; col<num_cols; col++){
				int[] cell_data = new int[5] {M [row, col, 0], M [row, col, 1], M [row, col, 2], M [row, col, 3], M [row, col, 4]};
				if(cell_data[0] == 1){
					CreateMazeWall (new IntVector2 (row, col), 0);
				}
				if(cell_data[1] == 1){
					CreateMazeWall (new IntVector2 (row, col), 1);
				}
				if(cell_data[2] == 1){
					CreateMazeWall (new IntVector2 (row, col), 2);
				}
				if(cell_data[3] == 1){
					CreateMazeWall (new IntVector2 (row, col), 3);
				}
				print (row + col);
				CreateCell (new IntVector2 (row, col));
			}
		}
		for (int i = 0; i < num_cols; i++) {
			CreateOuterMazeWall (new IntVector2 (0, i), 1);
			CreateOuterMazeWall (new IntVector2 (num_rows, i), 1);
		}
		for (int i = 0; i < num_rows; i++) {
			if (i != 10) {
				CreateOuterMazeWall (new IntVector2 (i, 0), 0);
			}
			CreateOuterMazeWall (new IntVector2 (i, num_cols), 0);
		}

	}
	public void Generate () {
		cells = new MazeCell[size.x, size.z];
		walls = new MazeWall[size.x, size.z];
		outerwalls = new MazeWall[size.x+2, size.z+2];
		GenV2 ();
	}

	private void CreateCell (IntVector2 coordinates) {
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition =
			new Vector3(coordinates.x*3 - size.x * 0.5f , 0f, coordinates.z*3 - size.z * 0.5f );
	}
	private void CreateOuterMazeWall(IntVector2 coordinates, int direction){
		MazeWall newWall = Instantiate(wallPrefab) as MazeWall;
		outerwalls[coordinates.x, coordinates.z] = newWall;
		newWall.coordinates = coordinates;
		newWall.name = "Maze Wall " + coordinates.x + ", " + coordinates.z;
		newWall.transform.parent = transform;
		print(newWall.transform.localScale.x);
		if (direction == 0) {
			newWall.transform.localPosition = new Vector3(coordinates.x*3 - size.x * 0.5f, newWall.transform.localScale.y/2, coordinates.z*3 - size.z * 0.5f-1.5f);
			newWall.transform.Rotate (0, 90, 0);
		}
		if (direction == 1) {
			newWall.transform.localPosition = new Vector3(coordinates.x*3 - size.x * 0.5f - 1.5f, newWall.transform.localScale.y/2, coordinates.z*3 - size.z * 0.5f );
		}
	}
	private void CreateMazeWall(IntVector2 coordinates, int direction){
		MazeWall newWall = Instantiate(wallPrefab) as MazeWall;
		walls[coordinates.x, coordinates.z] = newWall;
		newWall.coordinates = coordinates;
		newWall.name = "Maze Wall " + coordinates.x + ", " + coordinates.z;
		newWall.transform.parent = transform;
		if (direction == 0) {
						newWall.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f - 0.5f + newWall.transform.localScale.x/2, newWall.transform.localScale.y/2-100, coordinates.z - size.z * 0.5f+ newWall.transform.localScale.z/2 );
			newWall.transform.Rotate (0, 90, 0);
		}
		if (direction == 1) {
						newWall.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f+ newWall.transform.localScale.x/2, newWall.transform.localScale.y/2-100, coordinates.z - size.z * 0.5f - 0.5f+ newWall.transform.localScale.z/2);
		}
		if (direction == 2) {
						newWall.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f+ newWall.transform.localScale.x/2 , newWall.transform.localScale.y/2-100, coordinates.z - size.z * 0.5f + newWall.transform.localScale.z/2);
			newWall.transform.Rotate (0, 90, 0);
		}
		if (direction == 3) {
						newWall.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f+ newWall.transform.localScale.x/2-100 , newWall.transform.localScale.y/2, coordinates.z - size.z * 0.5f + 0.5f + newWall.transform.localScale.z/2);
		}
	}

}