using UnityEngine;
using UniRx;

public sealed class ScoreModel : MonoBehaviour
{
	private IntReactiveProperty ScoreProperty = new IntReactiveProperty(0);
	public IReadOnlyReactiveProperty<int> scoreProperty { get { return ScoreProperty; } }

	[SerializeField]
	private Transform playerTransform;
	private float playerMaxY;
	[SerializeField]
	private int ScoreRate;

	private void Awake()
	{
		playerTransform
		.ObserveEveryValueChanged(t => t.position.y)
		.Where(y => y == Mathf.Max(y, playerMaxY))
		.Subscribe(y =>
		{
			ScoreProperty.Value = (int)y * ScoreRate;

			playerMaxY = y;
		});
	}
}
