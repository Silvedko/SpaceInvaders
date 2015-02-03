using UnityEngine;
using System.Collections;
using System;

public enum InvadersSortingType 
{
	triangled = 0,
	squared = 1
}

[Serializable]
public class SIGameLevel : ScriptableObject 
{
	// flying invaders positions
	public Vector2 [] flyingInvadersPositions;

	//idle invaders positions
	public Vector2 [] idleInvadersPositions;

	//start player position
	public Vector2 playerPosition;

	//time until end of level
	public int levelTime;

	//how many times player can die
	public int playerLifeCount;

	//score for next level
	public int scoreForFiveStars;

	public InvadersSortingType sortingType;

}
