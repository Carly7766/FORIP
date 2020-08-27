using UnityEngine;

public class FloatingObjectGenerator
{
	private CellInitializer cellInitializer;
	private FloatingObjectCreatePointer floatingObjectPointer;
	private FloatingObjectCreator floatingObjectCreator;
	private FloatingObjectContainer floatingObjectContainer;

	public FloatingObjectGenerator()
	{
		cellInitializer = new CellInitializer();
		floatingObjectPointer = new FloatingObjectCreatePointer();
		floatingObjectCreator = new FloatingObjectCreator();
		floatingObjectContainer = new FloatingObjectContainer();

		Locator<FloatingObjectContainer>.Bind(floatingObjectContainer);
		Locator<FloatingObjectContainer>.Bind(floatingObjectContainer);
	}

	public void Generate(Vector2Int generateChunkPosition)
	{
		var cellChunk = cellInitializer.Initialize(generateChunkPosition);

		floatingObjectPointer.SetCreatePoint(ref cellChunk);
		floatingObjectCreator.Create(ref cellChunk);

		floatingObjectContainer.AddCellGroup(cellChunk);
	}
}