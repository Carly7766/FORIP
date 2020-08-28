using UnityEngine;

public class CellGizmoDrawer : MonoBehaviour
{
#if UNITY_IOS
	private CellChunkContainer container;

	private void Awake()
	{
		container = Locator<CellChunkContainer>.Resolve();
	}

	private void OnDrawGizmos()
	{
		if (!UnityEditor.EditorApplication.isPlaying) return;

		foreach (var cellChunk in container.CellGroup)
		{
			Gizmos.color = Color.green;
			foreach (var cell in cellChunk.cells)
			{
				Gizmos.DrawWireCube(cell.center, Vector2.one * cell.size);
			}
			Gizmos.color = Color.red;

			var cellChunkSize = new Vector2(cellChunk.cellSize * cellChunk.cells.GetLength(0), cellChunk.cellSize * cellChunk.cells.GetLength(1));
			var cellChunkPosition = ((Vector2)cellChunk.position * cellChunkSize) + new Vector2(0, cellChunkSize.y / 2);

			Gizmos.DrawWireCube(cellChunkPosition, cellChunkSize);
		}
	}
#endif
}