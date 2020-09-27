// using UnityEngine;
// using UniRx;
// using UniRx.Triggers;

// public class PlayerMoveArchDrawer : MonoBehaviour
// {
// 	private LineRenderer lineRenderer;

// 	private IInputProvider inputProvider;
// 	private Rigidbody2D playerRigidbody;
// 	private PlayerMover playerMover;

// 	[SerializeField]
// 	private int segmentCount = 20;
// 	[SerializeField]
// 	private float segmentScale = 1;

// 	private void Awake()
// 	{
// 		lineRenderer = GetComponent<LineRenderer>();

// 		inputProvider = Locator<IInputProvider>.Resolve();
// 		playerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
// 		playerMover = playerRigidbody.GetComponent<PlayerMover>();

// 		inputProvider.onDragStream
// 		.WithLatestFrom(this.FixedUpdateAsObservable(), (diff, _) => diff * playerMover.jumpPower)
// 		.Subscribe(force =>
// 		{
// 		});
// 	}
// }
