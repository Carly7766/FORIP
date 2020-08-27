using UnityEngine;

public class MainInitializer : MonoBehaviour
{
	[SerializeField]
	GenerateSetting generateSetting;

	private void Awake()
	{
		Locator<IInputProvider>.Bind(new InputProvider());


		Locator<GenerateSetting>.Bind(generateSetting);

		var floatingObjectGenerator = new FloatingObjectGenerator();
		Locator<FloatingObjectGenerator>.Bind(floatingObjectGenerator);

		floatingObjectGenerator.Generate(Vector2Int.zero);
	}
}
