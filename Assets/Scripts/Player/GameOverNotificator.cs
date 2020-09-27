using System;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameOverNotificator : MonoBehaviour
{
	private Transform transform;
	private Subject<Vector2> onVisibleStream = new Subject<Vector2>();
	public IObservable<Vector2> onGameOverStream { get { return onVisibleStream; } }

	private void Awake()
	{
		transform = GetComponent<Transform>();
		onVisibleStream.Subscribe(deathPosition =>
		{
			SceneManager.LoadScene(2);

		}).AddTo(this);
	}

	private void OnBecameInvisible()
	{
		onVisibleStream.OnNext(transform.position);
	}
}
