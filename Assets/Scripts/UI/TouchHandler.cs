using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour 
{
	public delegate void ShootDelegate ();
	public static event ShootDelegate OnTouchedScreen;
	
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
			CheckTouch ();
	}

	/// <summary>
	/// Checks the touch.
	/// </summary>
	void CheckTouch()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit01 = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);

		//Send event when touching screen but not controllers
		if (hit01.transform == null)
		{
			OnTouchedScreen ();
		}
		else if (hit01.transform.tag != "GameController")
		{
			OnTouchedScreen ();
		}
		
	}
}
