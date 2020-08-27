using UnityEngine;

public class CellChunk
{
	public Cell[,] cells;
	public Vector2Int position;
	public float cellSize { get { return cells[0, 0].size; } }

	public CellChunk(Cell[,] cells, Vector2Int position)
	{
		this.cells = cells;
		this.position = position;
	}
}
