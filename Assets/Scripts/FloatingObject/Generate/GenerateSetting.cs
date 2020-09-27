using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GenerateSetting", menuName = "Installers/GenerateSetting Installer")]
public class GenerateSetting : ScriptableObjectInstaller<GenerateSetting>
{
	public float cellSize;
	public int cellWidth;
	public int cellHeight;

	public float chunkSize { get { return cellSize * cellWidth; } }

	public GameObject[] prefabs;
	public Material prefabMaterial;

	public int generateBorderCellY;

	public override void InstallBindings()
	{
		Container.BindInstance(this);
	}
}