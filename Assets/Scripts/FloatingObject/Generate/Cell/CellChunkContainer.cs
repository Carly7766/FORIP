using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CellChunkContainer
{
	public List<CellChunk> CellGroup = new List<CellChunk>();
	public int CellGroupLength { get { return CellGroup.Count; } }

	public void AddCellGroup(CellChunk cellChunk)
	{
		CellGroup.Add(cellChunk);
	}

	public void DeleteCellGroup(Vector2Int chunkPosition)
	{
		var objectToDelete = CellGroup.Single(chunk => chunk.position == chunkPosition);
		objectToDelete.DestroyChunk();
		CellGroup.Remove(objectToDelete);
	}

	public bool CheckCellGroupExist(Vector2Int chunkPosition)
	{
		return CellGroup.Any(cellChunk => cellChunk.position == chunkPosition);
	}
}
