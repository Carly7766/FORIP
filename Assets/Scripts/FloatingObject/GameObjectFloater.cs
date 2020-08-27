using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class GameObjectFloater : MonoBehaviour
{
	[SerializeField]
	private float speed = 0.1f;
	[SerializeField]
	private float amplitude = 0f;

	private float delay = 0f;


	private Rigidbody2D rigidbody;

	private void Awake()
	{
		// rigidbody = GetComponent<Rigidbody2D>();

		// speed = Random.Range(0.05f, 0.01f);
		// amplitude = Random.Range(0.001f, 0.0005f);
		// delay = Random.Range(0f, 60f);


		// this.UpdateAsObservable()
		// 	.Subscribe(_ =>
		// 	{
		// 		float t = Time.time;
		// 		float posYSin = Mathf.Sin(2.0f * Mathf.PI * (speed * (delay - Time.time)));
		// 		rigidbody.position += new Vector2(0, amplitude * posYSin);
		// 	});
	}
}