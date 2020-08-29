using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerClimber : MonoBehaviour
{
	private IInputProvider inputProvider;
	private Rigidbody2D rigidbody;
	FloatingObjectJointConnector collisionJointConnector;

	private void Awake()
	{
		inputProvider = Locator<IInputProvider>.Resolve();
		rigidbody = GetComponent<Rigidbody2D>();


		this.OnCollisionEnter2DAsObservable()
		.Where(col => col.gameObject.CompareTag("Planet"))
		.Subscribe(col =>
		{
			collisionJointConnector = col.gameObject.GetComponent<FloatingObjectJointConnector>();
			collisionJointConnector.Connect(rigidbody);
		});

		inputProvider.onEndDragStream.Subscribe(_ =>
		{
			if (collisionJointConnector != null) collisionJointConnector.DeConnect();
		});
	}
}
