using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerBorderMonitor : MonoBehaviour
{
	private Vector2Int currentCellChunkPosition = new Vector2Int(0, 0);
	private GenerateSetting generateSetting;

	private void Awake()
	{
		generateSetting = Locator<GenerateSetting>.Resolve();

		var transform = GetComponent<Transform>();

		transform
		.ObserveEveryValueChanged(t => t.position)
		.Subscribe(playerPosition =>
		{
			var a = CheckBorderTop(playerPosition);
		});
	}

	private bool CheckBorderTop(Vector2 playerPosition)
	{
		var borderPositionY = generateSetting.cellSize * (generateSetting.generateBorderCellY - 1);
		return playerPosition.y > borderPositionY;
	}
}
