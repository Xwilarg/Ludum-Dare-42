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
        if (transform.position.x < -Hlen)
            Reposition();
	}

    private void Reposition()
    {
        Vector2 offset = new Vector2(Hlen * 2f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}
