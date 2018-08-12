using UnityEngine;

public class FenceScroll : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private PlayerController Pc;
    public float ScrollSpeed { set; get; }

    void Start()
    {
        Pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            ScrollSpeed = Pc.speed * Time.deltaTime * 1.5f;
            rb2d.velocity = new Vector2(-ScrollSpeed, 0f);
        }
    }

    void Update()
    {
        if (rb2d != null)
        {
            ScrollSpeed = Pc.speed * Time.deltaTime * 1.5f;
            rb2d.velocity = new Vector2(-ScrollSpeed, 0f);
        }
        else
            transform.Translate(new Vector2(-ScrollSpeed * Time.deltaTime, 0f));
        if (transform.position.x < -17 && (tag == "Character" || tag == "Trap"))
            Destroy(gameObject);
    }
}
