using System.Linq;
using System.Collections.Generic;

public class FloatingObjectContainer
{
	public List<CellChunk> CellGroup = new List<CellChunk>();
	public int CellGroupLength { get { return CellGroup.Count; } }

	public void AddCellGroup(CellChunk cellChunk)
	{
		CellGroup.Add(cellChunk);
	}

	public void DeleteCellGroup(int x, int y)
	{
		CellGroup.Single(chunk => chunk.position == new UnityEngine.Vector2Int(x, y));
	}
}
