using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelObject : ScriptableObject
{
	public string levelName;
	
	public int carrotTotal;
	public int currentCarrots;

	public bool isFinished;

	public float timeSpentInLevel;

	public int nextLevel;
}
