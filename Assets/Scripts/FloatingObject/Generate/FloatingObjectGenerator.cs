using UnityEngine;

public class FloatingObjectGenerator
{
	private CellInitializer cellInitializer;
	private FloatingObjectCreatePointer floatingObjectPointer;
	private FloatingObjectCreator floatingObjectCreator;
	private CellChunkContainer CellChunkContainer;

	public FloatingObjectGenerator()
	{
		cellInitializer = new CellInitializer();
		floatingObjectPointer = new FloatingObjectCreatePointer();
		floatingObjectCreator = new FloatingObjectCreator();

		CellChunkContainer = Locator<CellChunkContainer>.Resolve();
	}

	public void Generate(Vector2Int generateChunkPosition)
	{
		var cellChunk = cellInitializer.Initialize(generateChunkPosition);

		floatingObjectPointer.SetCreatePoint(ref cellChunk);
		floatingObjectCreator.Create(ref cellChunk);

		CellChunkContainer.AddCellGroup(cellChunk);
	}
}