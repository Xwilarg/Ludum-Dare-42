using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;
    private Rigidbody2D rb;
    private BeastComportement Bc;
    private SpriteRenderer sr;
    private bool exploded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 v = rb.velocity;
        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (exploded == false && collision.CompareTag("Beast") == true)
        {
            exploded = true;
            GameObject beast = collision.gameObject;
            while (beast.transform.parent != null)
                beast = beast.transform.parent.gameObject;
            Bc = beast.GetComponent<BeastComportement>();
            Bc.TakeDamage(10);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 1);
            sr.enabled = false;
            Destroy(gameObject, 1);
        }
    }
}
