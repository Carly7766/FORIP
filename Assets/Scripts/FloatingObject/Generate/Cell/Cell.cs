using UnityEngine;

public class Cell
{
	public Vector2 min { get; private set; }
	public Vector2 max { get; private set; }
	public Vector2 center { get { return (min + max) / 2; } }
	public float size { get { return Mathf.Abs(max.x - min.x); } }

	public FloatingObject floatingObject;

	public Cell(Vector2 min, Vector2 max)
	{
		this.min = min;
		this.max = max;
	}

	public void DestroyCell()
	{
		floatingObject.DestroyFloatingObject();
		floatingObject = null;
	}
}
