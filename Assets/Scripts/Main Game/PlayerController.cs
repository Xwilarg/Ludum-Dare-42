using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float speed = 300f;
    private List<MyCharacter> followers;

    public bool didLost { set; private get; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        followers = new List<MyCharacter>();
    }

    private void Update()
    {
        if (didLost)
            return;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            collision.GetComponent<BackgroundScroll>().enabled = false;
            if (followers.Count == 0)
            {
                collision.transform.parent = transform;
                collision.transform.position = transform.position + new Vector3(0f, -.2f);
            }
            else
            {
                MyCharacter charac = followers[followers.Count - 1];
                collision.transform.parent = charac.transform;
                collision.transform.position = charac.transform.position + new Vector3(0f, -.2f);
            }
            followers.Add(collision.GetComponent<MyCharacter>());
        }
    }
}
