using UnityEngine;
using System.Collections.Generic;

public class GenerateSetting : MonoBehaviour
{
	public float cellSize;
	public int cellWidth;
	public int cellHeight;

	public float chunkSize { get { return cellSize * cellWidth; } }

	public GameObject[] prefabs;

	public int generateBorderCellY;
}