using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : BaseInfo {

	private const int _bloodMax = 100;
	private const int _bloodMin = 0;
	private const int _attackMax = 100;
	private const int _defendMax = 100;




	// Use this for initialization
	void Start () {
		blood = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attacked()
	{
		blood -= 1;
	}

    public void Heal(int value)
	{
		blood += value;
	}

    public int GetBlood()
	{
		return blood;
	}

	public float GetBloodRatio()
	{
		return (float)blood / (float)_bloodMax;
	}
}
