using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    public Color[] colors;

    private SpriteRenderer sp;

	// Use this for initialization
	void Start ()
	{
	    sp = GetComponent<SpriteRenderer>();
	    int randomNum = Random.Range(0, colors.Length);
	    sp.color = colors[randomNum];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
