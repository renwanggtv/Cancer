using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInfo : BaseInfo {


	void Start()
	{
		blood = 3;
	}

	public void Attacked()
	{
		blood -= 1;
	}

    public int GetBlood()
	{
		return blood;
	}
}
