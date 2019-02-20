using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

    public GameObject food;
    
    public int xMin = -29;

    public int xMax = 29;

    public int yMin = -29;

    public int yMax = 29;

	// Use this for initialization
	void Start ()
	{
	    //InvokeRepeating("CreateFood", 0.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    CreateFood();
	}

    private void CreateFood()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);

        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity, transform);
    }
}
