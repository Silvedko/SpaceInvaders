using UnityEngine;
using System.Collections;

enum JoystickDirection : int 
{
	left = -1,
	right = 1
}

public class ShipMovementController : MonoBehaviour {

	[SerializeField]
	Transform spaceShip;

	[SerializeField]
	JoystickDirection jDir;

	bool shipCanMove = true;

	void Start () 
	{
		
	}
	
	void OnMouseDown () 
	{
		InvokeRepeating ("Move",0.05f, 0.05f);
	}

	void OnMouseUp ()
	{
		CancelInvoke ();
	}

	void Move ()
	{
		spaceShip.localPosition = new Vector3 (spaceShip.localPosition.x + 0.1f * (int)jDir, 
		                                       spaceShip.localPosition.y,
		                                       spaceShip.localPosition.z);
	}
}
