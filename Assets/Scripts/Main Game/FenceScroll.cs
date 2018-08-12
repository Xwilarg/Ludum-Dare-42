using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScroll : MonoBehaviour {

    private Rigidbody2D rb2d;
    [SerializeField]
    private PlayerController Pc;
    private float ScrollSpeed;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        ScrollSpeed = Pc.speed / 50;
        rb2d.velocity = new Vector2(-ScrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
        ScrollSpeed = Pc.speed / 50;
        rb2d.velocity = new Vector2(-ScrollSpeed, 0);
    }
}
