using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMini : MonoBehaviour
{
    [SerializeField]
    private GameObject MiniPrefab;
    private float delta;

	void Start () {
        delta = Time.time;		
	}
	
	// Update is called once per frame
	void Update () {
        float rDelta = Time.time;

        if (rDelta - delta > 1f)
        {
            GameObject mini = Instantiate(MiniPrefab, transform.position, Quaternion.identity);
            delta = rDelta;
        }
    }
}
