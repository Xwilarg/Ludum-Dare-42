using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOn : MonoBehaviour {

    private PlayerController Pc;
    private Rigidbody2D rb;
    private Transform target;
   
    private void Start () {
        Pc = transform.parent.gameObject.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        target = Pc.transform;
        JumpOnCharacter();
	}

    private void TakeDamage(float value)
    {
        Destroy(gameObject);
    }

    private void Update()
    { 
        if (transform.position.y <= 0)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
        if (transform.position.x > 30)
            Destroy(gameObject);
    }

    private void JumpOnCharacter()
    {
        float JumpPower = Random.Range(7, 10);
        rb.gravityScale = 1f;
        rb.AddForce(new Vector2(JumpPower, JumpPower), ForceMode2D.Impulse);
    }
}
