using UnityEngine;

public class CellInitializer
{
	private GenerateSetting generateSetting;

	public CellInitializer()
	{
		this.generateSetting = Locator<GenerateSetting>.Resolve();
	}

	public CellChunk Initialize(Vector2Int chunkPosition)
	{
		var cells = new Cell[generateSetting.cellWidth, generateSetting.cellHeight];

		var cellBasePosition = new Vector2(generateSetting.chunkSize * (float)chunkPosition.x, generateSetting.chunkSize * (float)chunkPosition.y);

		for (int x = 0; x < generateSetting.cellWidth; x++)
		{
			for (int y = 0; y < generateSetting.cellHeight; y++)
			{
				var xMin = x * generateSetting.cellSize - (generateSetting.chunkSize / 2);
				var xMax = (x + 1) * generateSetting.cellSize - (generateSetting.chunkSize / 2);

				var yMin = y * generateSetting.cellSize;
				var yMax = (y + 1) * generateSetting.cellSize;

				cells[x, y] = new Cell(cellBasePosition + new Vector2(xMin, yMin), cellBasePosition + new Vector2(xMax, yMax));
			}
		}

		return new CellChunk(cells, chunkPosition);
	}
}
