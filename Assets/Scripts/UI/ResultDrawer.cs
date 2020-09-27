using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDrawer : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<UnityEngine.UI.Text>().text = $"Score:{(int)ScoreModel.playerMaxY}m";
	}
}
