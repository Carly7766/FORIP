using UnityEngine;
using Zenject;

public class GameInitializer : MonoBehaviour
{
	[Inject]
	private FloatingObjectGenerator generator;
	public void Initialize()
	{
		generator.Generate(Vector2Int.zero);
	}
}
