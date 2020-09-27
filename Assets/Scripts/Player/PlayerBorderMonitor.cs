using UnityEngine;
using UniRx;
using Zenject;

public class PlayerBorderMonitor : MonoBehaviour
{
	private Vector2Int currentCellChunkPosition = new Vector2Int(0, 0);

	[Inject] private GenerateSetting generateSetting;
	[Inject] private FloatingObjectGenerator floatingObjectGenerator;
	[Inject] private CellChunkContainer cellChunkContainer;

	private void Awake()
	{

		var transform = GetComponent<Transform>();


		var borderTopExceededObservable = transform.ObserveEveryValueChanged(t => t.position).Where(playerPosition => CheckExceededBorderTop(playerPosition));


		var deleteTopStream = borderTopExceededObservable
		.Subscribe(playerPosition =>
		{
			var deleteChunkPosition = currentCellChunkPosition + new Vector2Int(0, -2);
			if (cellChunkContainer.CheckCellGroupExist(deleteChunkPosition))
			{
				cellChunkContainer.DeleteCellGroup(deleteChunkPosition);
			}
		});

		var generateTopStream = borderTopExceededObservable
		.Subscribe(playerPosition =>
		{
			var generateChunkPosition = currentCellChunkPosition + new Vector2Int(0, 1);
			if (!cellChunkContainer.CheckCellGroupExist(generateChunkPosition))
			{
				floatingObjectGenerator.Generate(generateChunkPosition);

				currentCellChunkPosition += new Vector2Int(0, 1);
			}
		});
	}

	private bool CheckExceededBorderTop(Vector2 playerPosition)
	{
		var borderPositionY = generateSetting.cellSize * (generateSetting.generateBorderCellY - 1);
		return playerPosition.y > borderPositionY + ((float)currentCellChunkPosition.y * generateSetting.cellHeight * generateSetting.cellSize);
	}
}
