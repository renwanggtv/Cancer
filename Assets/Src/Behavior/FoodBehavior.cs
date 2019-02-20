using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FoodState
{
	patrol = 1,
    follow = 2,
		
}

public class FoodBehavior : MonoBehaviour {

	private const float followDistance = 5.0f;

	private Vector2 petrolPointA;

	private Vector2 petrolPointB;

	private FoodState currentState;

	private Vector2 currentDestination;

	private Transform playerTrans;

	private float timer;
    
	private float speed = 1;
	// Use this for initialization
	void Start () {
		petrolPointA = transform.localPosition;
		//petrolPointB = new Vector2(Random.Range(-29, 29), Random.Range(-29, 29));
		petrolPointB = new Vector2(29, 29);
		currentState = FoodState.patrol;
		currentDestination = petrolPointB;

		playerTrans = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		return;
		float angle = 0;
		if (CheckIfFoundPlayer() || timer > 0.0f)
		{
			Vector2 direction = new Vector2(GetPlayerLocalPosition().x - transform.localPosition.x, GetPlayerLocalPosition().y - transform.localPosition.y);
			angle = Vector2.Angle(Vector3.right, direction);
			timer -= Time.deltaTime;
		}
		else
		{
			if (Vector2.Distance(transform.localPosition, currentDestination) < 1.0f)
			{
				SwitchDestination();
			}


			Vector2 direction = new Vector2(currentDestination.x - transform.localPosition.x, currentDestination.y - transform.localPosition.y);
			angle = Vector2.Angle(Vector3.right, direction);
		}

		float x = Mathf.Sin(angle) * speed * Time.deltaTime;
		float y = Mathf.Cos(angle) * speed * Time.deltaTime;
		transform.Translate(x, y, 0);
	}

    private bool CheckIfFoundPlayer()
	{

		var dist = GetPlayerDistance();
		if (dist > followDistance)
		{
			currentState = FoodState.patrol;
			return false;
		}

		timer = 4.0f;
		currentState = FoodState.follow;
		return true;
	}

    private float GetPlayerDistance()
	{
		var playerPosition = GetPlayerLocalPosition();

        var dist = Vector2.Distance(playerPosition, transform.localPosition);

		return dist;
	}

	private Vector2 GetPlayerLocalPosition()
	{
		return playerTrans.localPosition;
	}

	private void SwitchDestination()
	{
		if (currentDestination == petrolPointB)
		{
			currentDestination = petrolPointA;
		}
		else
		{
			currentDestination = petrolPointB;
		}
	}


}
