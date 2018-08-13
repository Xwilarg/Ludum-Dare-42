using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMini : MonoBehaviour
{
    [SerializeField]
    private GameObject MiniPrefab;
    [SerializeField]
    public GameObject Pc;
    private float delta;

	void Start () {
        Pc = GameObject.FindGameObjectWithTag("Player");
        delta = Time.time;		
	}
	
	// Update is called once per frame
	void Update () {
        float rDelta = Time.time;

        if (rDelta - delta > 3f)
        {
            GameObject mini = Instantiate(MiniPrefab, transform.position, Quaternion.identity);
            mini.transform.SetParent(Pc.transform);
            delta = rDelta;
        }
    }
}
