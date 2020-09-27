using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class PlayerMover : MonoBehaviour
{
	[Inject]
	private IInputProvider inputProvider;
	private Rigidbody2D rigidbody;

	public float jumpPower { get; private set; } = 50;
	private int jumpCount = 2;
	public bool isGround { get; private set; } = true;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();

		inputProvider.onStartDragStream
		.Zip(inputProvider.onEndDragStream, (startPos, endPos) => startPos - endPos)
		.WithLatestFrom(this.FixedUpdateAsObservable(), (diff, _) => diff * jumpPower)
		.Where(_ => jumpCount > 0)
		.Subscribe(force =>
		{
			rigidbody.AddForce(force);
			jumpCount--;
			isGround = false;
		});

		this.OnCollisionEnter2DAsObservable().Subscribe(_ =>
		{
			isGround = true;
			jumpCount = 2;
		});
	}
}
