using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Text lostText;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Image[] images;
    private int index;

    private Rigidbody2D rb;
    private Animator anim;
    public float speed { set; get; }
    public bool isJumping { private set; get; }
    private Vector2 jumpPos;

    public bool didLost { set; get; }

    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        speed = 300f;
        anim = GetComponent<Animator>();
        index = 0;
    }

    private void Update()
    {
        if (didLost)
        {
            if (!gameOverPanel.activeInHierarchy)
            {
                Time.timeScale = 0f;
                gameOverPanel.SetActive(true);
            }
            return;
        }
        anim.speed = speed / 300f;
        if (isJumping && transform.position.y <= jumpPos.y)
        {
            isJumping = false;
            rb.gravityScale = 0f;
        }
        else if (!isJumping)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * speed - new Vector2(100f * Time.deltaTime, 0f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpPos = transform.position;
                rb.gravityScale = 1f;
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                transform.Translate(new Vector2(0f, 0.05f));
                rb.AddForce(new Vector2(0f, speed / 37.5f), ForceMode2D.Impulse);
            }
        }
    }

    public void Loose()
    {
        didLost = true;
        rb.velocity = Vector2.zero;
        lostText.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") && !isJumping)
        {
            if (index == images.Length - 1)
            {
                images[index].color = Color.white;
                Loose();
            }
            else
            {
                images[index].color = Color.white;
                index++;
            }
        }
        if (collision.CompareTag("Beast"))
            Loose();
    }
}
