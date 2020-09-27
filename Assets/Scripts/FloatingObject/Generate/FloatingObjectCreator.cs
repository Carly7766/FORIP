using UnityEngine;
using Zenject;


public class FloatingObjectCreator
{
	[Inject]
	private GenerateSetting generateSetting;

	public void Create(ref CellChunk cellChunk)
	{
		foreach (var cell in cellChunk.cells)
		{
			var floatingObject = GameObject.Instantiate(generateSetting.prefabs[Random.Range(0, generateSetting.prefabs.Length)], cell.floatingObject.position, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
			floatingObject.transform.localScale = new Vector2(cell.floatingObject.size, cell.floatingObject.size);

			floatingObject.GetComponent<SpriteRenderer>().material = generateSetting.prefabMaterial;


			cell.floatingObject.gameObject = floatingObject;
		}
	}
}
