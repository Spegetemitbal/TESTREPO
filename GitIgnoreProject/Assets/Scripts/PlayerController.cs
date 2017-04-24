using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	private Rigidbody2D rb;
	public Vector2 jumpForce = new Vector2(0, 300);


	// Update is called once per frame
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> (); 
	}


	void Update ()
	{
		// Jump
		if (Input.GetKeyUp("space"))												
		{
			rb.velocity = Vector2.zero;
			rb.AddForce(jumpForce);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "enemy")
		{
			gameObject.SetActive (false);
			LoseScreen.Setactive (true);
	}
}
}