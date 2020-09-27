using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class PlayerClimber : MonoBehaviour
{
	[Inject] private IInputProvider inputProvider;
	private Rigidbody2D rigidbody;
	FloatingObjectJointConnector collisionJointConnector;

	private void Awake()
	{
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
