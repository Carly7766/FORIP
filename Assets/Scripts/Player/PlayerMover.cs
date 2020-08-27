using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerMover : MonoBehaviour
{
	private IInputProvider inputProvider;
	private Rigidbody2D rigidbody;

	private void Start()
	{
		inputProvider = Locator<IInputProvider>.Resolve();
		rigidbody = GetComponent<Rigidbody2D>();

		var onDraggedStream = inputProvider.onStartDragStream
		.Zip(inputProvider.onEndDragStream, (startPos, endPos) => startPos - endPos)
		.WithLatestFrom(this.FixedUpdateAsObservable(), (diff, _) => diff)
		.Subscribe(diff =>
		{
			rigidbody.AddForce(diff * 40);
			rigidbody.simulated = true;
		});


		this.OnCollisionEnter2DAsObservable()
		.Where(col => col.gameObject.CompareTag("Planet"))
		.Subscribe(col =>
		{
			rigidbody.velocity = Vector2.zero;
			rigidbody.simulated = false;
		});
	}
}