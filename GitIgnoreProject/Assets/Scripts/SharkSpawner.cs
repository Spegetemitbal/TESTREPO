using UnityEngine;
using System.Collections;

public class SharkSpawner : MonoBehaviour 
{
	public GameObject SharkPrefab;                                 //The column game object.
	public int SharkPoolSize = 5;                                  //How many columns to keep on standby.
	public float spawnRate = 3f;                                    //How quickly columns spawn.
	public float SharkMin = -1f;                                   //Minimum y value of the column position.
	public float SharkMax = 3.5f;                                  //Maximum y value of the column position.

	private GameObject[] Shark;                                   //Collection of pooled columns.
	private int currentColumn = 0;                                  //Index of the current column in the collection.
	private bool GameOver = true;

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);     //A holding position for our unused columns offscreen.
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		Shark = new GameObject[SharkPoolSize];
		//Loop through the collection... 
		for(int i = 0; i < SharkPoolSize; i++)
		{
			//...and create the individual columns.
			Shark[i] = (GameObject)Instantiate(SharkPrefab, objectPoolPosition, Quaternion.identity);
		}
	}


	//This spawns columns as long as the game is not over.
	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (GameOver == true && timeSinceLastSpawned >= spawnRate) 
		{   
			timeSinceLastSpawned = 0f;

			//Set a random y position for the column
			float spawnYPosition = Random.Range(SharkMin, SharkMax);

			//...then set the current column to that position.
			Shark[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

			//Increase the value of currentColumn. If the new size is too big, set it back to zero
			currentColumn ++;

			if (currentColumn >= SharkPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}