using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{

	public void Shoot ()
	{
		this.rigidbody2D.AddForce (Vector2.up);
	}

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}
}
