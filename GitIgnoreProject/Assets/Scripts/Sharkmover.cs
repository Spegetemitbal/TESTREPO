using UnityEngine;
using System.Collections;

public class Sharkmover : MonoBehaviour {

	public Vector2 velocity = new Vector2(-4, 0);
	private Rigidbody2D srb;
	[SerializeField]
	float speed = 200;

	// Use this for initialization

		
	// Update is called once per frame
	void OnEnable () 
	{
		srb = GetComponent<Rigidbody2D> (); 
		srb.AddForce (Vector2.left * speed, ForceMode2D.Force);
	}																			
}
