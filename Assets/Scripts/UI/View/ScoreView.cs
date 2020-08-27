using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
	[SerializeField]
	private Text text;

	public void DrawScore(int score)
	{
		text.text = $"{score}m";
	}
}
