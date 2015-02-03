using UnityEngine;
using System.Collections;

public class SpaceshipMovementController : MonoBehaviour 
{
	public delegate void ShipMoveDelegate();
	public static event ShipMoveDelegate OnLeftControllerClicked;
	public static event ShipMoveDelegate OnRightControllerClicked;

	public bool isLeftDirection = false;

	void Start ()
	{
		//Reposition controllers at bottom corners of screen
		if(isLeftDirection)
			PositionHelper.RepositionSprite(this.gameObject, ScreenCorners.bottomLeft);
		else
			PositionHelper.RepositionSprite(this.gameObject, ScreenCorners.bottomRight);
	}

	void OnMouseDown () 
	{
		CancelInvoke ();
		if(isLeftDirection)	
			InvokeRepeating ("MoveLeft",0.05f, 0.05f);
		else
			InvokeRepeating ("MoveRight",0.05f, 0.05f);
	}

	void OnMouseUp ()
	{
		CancelInvoke ();
	}

	void MoveLeft ()
	{	
		if(OnLeftControllerClicked != null)
			OnLeftControllerClicked();
	}

	void MoveRight ()
	{	
		if(OnRightControllerClicked != null)
			OnRightControllerClicked ();
	}
}
