using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.rotation = 
            Quaternion.Euler(0f, 0f, Quaternion.LookRotation(transform.position + new Vector3(rb.velocity.x, rb.velocity.y, 0f)).eulerAngles.z);
    }
}
