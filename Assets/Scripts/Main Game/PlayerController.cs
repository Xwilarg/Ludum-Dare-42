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
    [SerializeField]
    private Text scoreText;
    public float score { set; get; }
    private int index;
    private bool inTrap;

    private Rigidbody2D rb;
    private Animator anim;
    public float speed { set; get; }
    public bool isJumping { private set; get; }
    private Vector2 jumpPos;

    public bool didLost { set; get; }

    private void Start()
    {
        score = 0f;
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        speed = 300f;
        anim = GetComponent<Animator>();
        index = 0;
        inTrap = false;
    }

    private void Update()
    {
        if (didLost)
        {
            if (!gameOverPanel.activeInHierarchy)
            {
                Time.timeScale = 0f;
                gameOverPanel.SetActive(true);
                scoreText.text = "Score: " + score;
            }
            return;
        }
        anim.speed = speed / 300f;
        score += speed * Time.deltaTime;
        scoreText.text = "Score: " + score;
        if (isJumping && transform.position.y <= jumpPos.y)
        {
            gameObject.layer = 0;
            isJumping = false;
            rb.gravityScale = 0f;
            if (inTrap)
                TakeDamage();
        }
        else if (!isJumping)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * speed - new Vector2(100f * Time.deltaTime, 0f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.layer = 11;
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

    private void TakeDamage()
    {
        if (index == images.Length - 1)
        {
            images[index].color = Color.white;
            score -= 30000f;
            Loose();
        }
        else
        {
            images[index].color = Color.white;
            score -= 30000f;
            index++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
            inTrap = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            inTrap = true;
            if (!isJumping)
                TakeDamage();
        }
        if (collision.CompareTag("Beast"))
            Loose();
    }
}
