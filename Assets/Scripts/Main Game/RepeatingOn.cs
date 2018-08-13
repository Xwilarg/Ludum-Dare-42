using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingOn : MonoBehaviour
{
    private BoxCollider2D fCollider;
    private float Hlen;

	void Start ()
    {
        fCollider = GetComponent<BoxCollider2D>();
        Hlen = fCollider.size.x;
	}
	
	void Update ()
    {
        if (transform.position.x + Hlen <= 0)
            Reposition(0 - (transform.position.x + Hlen));
	}

    private void Reposition(float pos)
    {
        Vector3 offset = new Vector3(Hlen * 2.0f - pos, 0f, 0f);
        transform.position += offset;
    }
}
