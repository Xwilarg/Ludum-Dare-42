using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOn : MonoBehaviour {

    private Rigidbody2D rb;
    private float yFall;

    private void Start () {
        rb = GetComponent<Rigidbody2D>();
        JumpOnCharacter();
        yFall = Random.Range(-2f, 1.8f);
	}

    private void TakeDamage(float value)
    {
        Destroy(gameObject);
    }

    private void Update()
    { 
        if (transform.position.y <= yFall)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
        if (transform.position.x > 30)
            Destroy(gameObject);
    }

    private void JumpOnCharacter()
    {
        float JumpPower = Random.Range(5, 8);
        rb.gravityScale = 1f;
        rb.AddForce(new Vector2(JumpPower, JumpPower), ForceMode2D.Impulse);
    }
}
