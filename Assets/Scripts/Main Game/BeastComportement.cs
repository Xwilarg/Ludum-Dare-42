﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastComportement : MonoBehaviour
{
    [SerializeField]
    private GameObject PBar;
    [SerializeField]
    private GameObject Player;

    private float speed = -20;
    private float maxCapacitor = 18;
	
	void Update ()
    {
        float rspeed = speed + (280 - Player.GetComponent<PlayerController>().speed);
        transform.Translate(new Vector2(rspeed * Time.deltaTime / maxCapacitor, 0f));
	}
}
