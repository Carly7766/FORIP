using UnityEngine;
using Zenject;

public class FloatingObjectGenerator
{
	[Inject] private CellInitializer cellInitializer;
	[Inject] private FloatingObjectCreatePointer floatingObjectPointer;
	[Inject] private FloatingObjectCreator floatingObjectCreator;
	[Inject] private CellChunkContainer CellChunkContainer;

	public void Generate(Vector2Int generateChunkPosition)
	{
		var cellChunk = cellInitializer.Initialize(generateChunkPosition);

		floatingObjectPointer.SetCreatePoint(ref cellChunk);
		floatingObjectCreator.Create(ref cellChunk);

		CellChunkContainer.AddCellGroup(cellChunk);
	}
}