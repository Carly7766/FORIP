using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerBorderMonitor : MonoBehaviour
{
	private Vector2Int currentCellChunkPosition = new Vector2Int(0, 0);
	private GenerateSetting generateSetting;
	private FloatingObjectGenerator floatingObjectGenerator;
	private CellChunkContainer cellChunkContainer;

	private void Awake()
	{
		generateSetting = Locator<GenerateSetting>.Resolve();
		floatingObjectGenerator = Locator<FloatingObjectGenerator>.Resolve();
		cellChunkContainer = Locator<CellChunkContainer>.Resolve();

		var transform = GetComponent<Transform>();

		transform
		.ObserveEveryValueChanged(t => t.position)
		.Subscribe(playerPosition =>
		{
			var isExceededBorderTop = CheckBorderTop(playerPosition);
			if (isExceededBorderTop)
			{
				var generateChunkPosition = currentCellChunkPosition + new Vector2Int(0, 1);
				var isExistCellChunkTop = cellChunkContainer.CheckCellGroupExist(generateChunkPosition);
				if (!isExistCellChunkTop)
				{
					floatingObjectGenerator.Generate(generateChunkPosition);

					currentCellChunkPosition += new Vector2Int(0, 1);
				}
			}
		});
	}

	private bool CheckBorderTop(Vector2 playerPosition)
	{
		var borderPositionY = generateSetting.cellSize * (generateSetting.generateBorderCellY - 1);
		Debug.Log($"{playerPosition}, {borderPositionY + ((float)currentCellChunkPosition.y * generateSetting.cellSize)}");
		return playerPosition.y > borderPositionY + ((float)currentCellChunkPosition.y * generateSetting.cellHeight * generateSetting.cellSize);
	}
}
