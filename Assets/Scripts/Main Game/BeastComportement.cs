using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastComportement : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private HealthManager hm;
    
    private float maxCapacitor = 18;
	
    public void TakeDamage(float value)
    {
        hm.TakeDamage(value);
    }

    private void Start()
    {
        hm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<HealthManager>();
    }

    private void Update()
    {
        float rspeed = (295 - Player.GetComponent<PlayerController>().speed);
        transform.Translate(new Vector2(rspeed * Time.deltaTime / maxCapacitor, 0f));
	}
}
