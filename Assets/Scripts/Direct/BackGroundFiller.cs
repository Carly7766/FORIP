using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class BackGroundFiller : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private Camera mainCamera;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		mainCamera = Camera.main;

		this.UpdateAsObservable()
		.Subscribe(_ => FillScreen());
	}

	private void FillScreen()
	{
		float worldScreenHeight = mainCamera.orthographicSize * 2f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		float width = spriteRenderer.sprite.bounds.size.x;
		float height = spriteRenderer.sprite.bounds.size.y;

		transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height);
	}
}
