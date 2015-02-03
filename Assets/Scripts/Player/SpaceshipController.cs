using UnityEngine;
using System.Collections;

public class SpaceshipController : MonoBehaviour 
{
		public ScreenCorners screenPosition = ScreenCorners.bottomCenter;
		Transform _transform;
		Rigidbody2D _rigidbody2D;

		void OnEnable ()
		{
			TouchHandler.OnTouchedScreen += HandleOnTouchedScreen;
			SpaceshipMovementController.OnLeftControllerClicked += HandleOnLeftControllerClicked;
			SpaceshipMovementController.OnRightControllerClicked += HandleOnRightControllerClicked;
		}
	
		void OnDisable ()
		{ 
			TouchHandler.OnTouchedScreen -= HandleOnTouchedScreen;
			SpaceshipMovementController.OnLeftControllerClicked -= HandleOnLeftControllerClicked;
			SpaceshipMovementController.OnRightControllerClicked -= HandleOnRightControllerClicked;
		}

		void Start () 
		{
			PositionHelper.RepositionSprite(this.gameObject, screenPosition);
			_transform = transform;
			_rigidbody2D = this.rigidbody2D;
		}


#region event handlers

		void HandleOnTouchedScreen ()
		{
			Debug.Log ("Shoot!");
		}
			

		void HandleOnRightControllerClicked ()
		{
			if(_transform.position.x > 6.6f)
				return;

			_rigidbody2D.AddForce(Vector2.right);
		}


		void HandleOnLeftControllerClicked ()
		{
			if(_transform.position.x < -6.6f)
				return;

			_rigidbody2D.AddForce(Vector2.right * -1);
		}

#endregion

}
