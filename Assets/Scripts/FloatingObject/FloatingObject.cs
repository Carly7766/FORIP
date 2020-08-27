using UnityEngine;

public class FloatingObject
{
	public GameObject gameObject;
	public Vector2 position;
	public float size;

	public FloatingObject(Vector2 position, float size)
	{
		this.position = position;
		this.size = size;
	}

	public void DestroyFloatingObject()
	{
		GameObject.Destroy(gameObject);
	}
}
