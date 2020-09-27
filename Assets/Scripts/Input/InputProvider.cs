using System;
using UnityEngine;
using UniRx;

public class InputProvider : IInputProvider
{
	public IObservable<Vector2> onStartDragStream { get; private set; }
	public IObservable<Vector2> onDragStream { get; private set; }
	public IObservable<Vector2> onEndDragStream { get; private set; }
	public Camera mainCamera { get; set; }

	// public Camera mainCamera;

	public InputProvider()
	{
		mainCamera = Camera.main;

		onStartDragStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition));

		onEndDragStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0)).Select(_ => (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition));

		var mousePositionAsObservable = Observable.EveryUpdate().Where(_ => Input.GetMouseButton(0)).Select(_ => (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition));

		onDragStream = mousePositionAsObservable
		.SkipUntil(onStartDragStream)
		.TakeUntil(onEndDragStream)
		.DistinctUntilChanged()
		.Repeat();
	}
}
