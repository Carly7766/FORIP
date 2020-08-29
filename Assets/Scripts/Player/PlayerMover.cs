using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerMover : MonoBehaviour
{
	private IInputProvider inputProvider;
	private Rigidbody2D rigidbody;

	private int jumpCount = 1;

	public IObservable<Vector2> onMoveStream;

	private void Awake()
	{
		inputProvider = Locator<IInputProvider>.Resolve();
		rigidbody = GetComponent<Rigidbody2D>();

		onMoveStream = inputProvider.onStartDragStream
		.Zip(inputProvider.onEndDragStream, (startPos, endPos) => startPos - endPos)
		.WithLatestFrom(this.FixedUpdateAsObservable(), (diff, _) => diff);

		onMoveStream.Subscribe(diff =>
		{
			rigidbody.AddForce(diff * 40);
		});
	}
}
