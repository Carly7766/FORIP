using System;
using UnityEngine;
using UniRx;

public class ScorePresenter : MonoBehaviour
{
	[SerializeField]
	private ScoreModel scoreModel;
	[SerializeField]
	private ScoreView scoreView;

	void Awake()
	{
		scoreModel.scoreProperty.Subscribe(scoreView.DrawScore);
	}
}