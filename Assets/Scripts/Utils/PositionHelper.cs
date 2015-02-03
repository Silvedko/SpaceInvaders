using UnityEngine;
using System.Collections;

public enum ScreenCorners
{
	topLeft,
	topCenter,
	topRight,
	centerLeft,
	center,
	centerRight,
	bottomLeft,
	bottomCenter,
	bottomRight
}

public class PositionHelper 
{

	/// <summary>
	/// Reposition the specified Gameobject with SpriteRenderer at corner of screen.
	/// </summary>
	/// <param name="go">Go.</param>
	/// <param name="corner">Corner.</param>
	public static void RepositionSprite (GameObject go, ScreenCorners corner) 
	{
		Bounds bounds = go.GetComponent<SpriteRenderer>().bounds;

		Vector3 newPosition = GetScreenPosition(corner);

		switch (corner)
		{
			case ScreenCorners.topLeft:
			newPosition += new Vector3(bounds.size.x / 2, -bounds.size.y / 2, 0); 
			break;

			case ScreenCorners.topCenter:
			newPosition += new Vector3(0,-bounds.size.y / 2, 0);
			break;

			case ScreenCorners.topRight:
			newPosition += new Vector3(-bounds.size.x / 2, -bounds.size.y / 2, 0);
			break;

			case ScreenCorners.centerLeft:
			newPosition += new Vector3(bounds.size.x / 2, 0, 0);
			break;

			case ScreenCorners.center:
			break;

			case ScreenCorners.centerRight:
			newPosition += new Vector3(-bounds.size.x / 2, 0, 0);
			break;

			case ScreenCorners.bottomLeft:
			newPosition += new Vector3(bounds.size.x / 2, bounds.size.y / 2, 0); 
			break;

			case ScreenCorners.bottomCenter:
			newPosition += new Vector3(0, bounds.size.y / 2, 0);
			break;

			case ScreenCorners.bottomRight:
			newPosition += new Vector3(-bounds.size.x / 2, bounds.size.y / 2, 0);
			break;

			default:
			newPosition = go.transform.position;
			break;
		}

		go.transform.position = newPosition;        
	}

	public static Vector3 GetScreenPosition (ScreenCorners pos)
	{
		float camHalfHeight = Camera.main.orthographicSize;
		float camHalfWidth = Camera.main.aspect * camHalfHeight; 
		
		Vector3 newPosition;

		switch (pos)
		{
			case ScreenCorners.topLeft:
			newPosition = new Vector3(-camHalfWidth, camHalfHeight, 0) + Camera.main.transform.position ; 
			break;
			
			case ScreenCorners.topCenter:
			newPosition = new Vector3(0, camHalfHeight, 0) + Camera.main.transform.position ;
			break;
			
			case ScreenCorners.topRight:
			newPosition = new Vector3(camHalfWidth, camHalfHeight, 0) + Camera.main.transform.position ;
			break;
			
			case ScreenCorners.centerLeft:
			newPosition = new Vector3(-camHalfWidth, 0, 0) + Camera.main.transform.position ;
			break;
			
			case ScreenCorners.center:
			newPosition = Vector3.zero + Camera.main.transform.position;
			break;
			
			case ScreenCorners.centerRight:
			newPosition = new Vector3(camHalfWidth, 0, 0) + Camera.main.transform.position ;
			break;
			
			case ScreenCorners.bottomLeft:
			newPosition = new Vector3(-camHalfWidth, -camHalfHeight, 0) + Camera.main.transform.position ; 
			break;
			
			case ScreenCorners.bottomCenter:
			newPosition = new Vector3(0, -camHalfHeight, 0) + Camera.main.transform.position ;
			break;
			
			case ScreenCorners.bottomRight:
			newPosition = new Vector3(camHalfWidth, -camHalfHeight, 0) + Camera.main.transform.position ;
			break;
			
			default:
			newPosition = Vector3.zero;
			break;
		}

		return newPosition;
	}

}

