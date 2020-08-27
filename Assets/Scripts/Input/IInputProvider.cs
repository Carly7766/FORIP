using System;
using UnityEngine;

public interface IInputProvider
{
	IObservable<Vector2> onStartDragStream { get; }
	IObservable<Vector2> onDragStream { get; }
	IObservable<Vector2> onEndDragStream { get; }
}
