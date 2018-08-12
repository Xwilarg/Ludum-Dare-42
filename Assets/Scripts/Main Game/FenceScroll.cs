using UnityEngine;

public class FenceScroll : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private PlayerController Pc;
    private float ScrollSpeed;
    public float? speed { set; private get; }

    void Start()
    {
        Pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        ScrollSpeed = Pc.speed * Time.deltaTime * 1.5f;
        rb2d.velocity = new Vector2(-ScrollSpeed, 0);
    }

    void Update()
    {
        ScrollSpeed = Pc.speed * Time.deltaTime * 1.5f;
        rb2d.velocity = new Vector2(-ScrollSpeed, 0);
        if (transform.position.x < -17 && (tag == "Character" || tag == "Trap"))
            Destroy(gameObject);
    }
}
