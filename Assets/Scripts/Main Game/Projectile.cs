using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private BeastComportement Bc;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 v = rb.velocity;
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Beast") == true)
        {
            GameObject beast = collision.gameObject;
            while (beast.transform.parent != null)
                beast = beast.transform.parent.gameObject;
            Bc = beast.GetComponent<BeastComportement>();
            Bc.TakeDamage(10);
            Destroy(this);
        }
    }
}
