using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMini : MonoBehaviour
{
    [SerializeField]
    private GameObject MiniPrefab;
    [SerializeField]
    public PlayerController Pc;
    private float delta;

	void Start () {
        Pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        delta = Time.time;		
	}
	
	// Update is called once per frame
	void Update () {
        float rDelta = Time.time;

        if (rDelta - delta > 3f)
        {
            GameObject mini = Instantiate(MiniPrefab, transform.position, Quaternion.identity);
            mini.transform.SetParent(transform);
            delta = rDelta;
        }
    }
}
