using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GameObject descriptionPanel;
    public GameObject bulletPrefab;
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
        if (Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("main");
        if (Input.GetKeyDown(KeyCode.Escape))
            descriptionPanel.SetActive(false);
        if (didLost)
        {
            if (!gameOverPanel.activeInHierarchy)
            {
                Time.timeScale = 0f;
                gameOverPanel.SetActive(true);
                scoreText.text = "Score: " + score.ToString("00");
            }
            return;
        }
        anim.speed = speed / 300f;
        score += speed * Time.deltaTime;
        scoreText.text = "Score: " + score.ToString("00");
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

    public bool Heal()
    {
        if (index == 0)
            return (false);
        index--;
        images[index].color = new Color(1f, 0f, 0.3176f);
        return (true);
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
        if (collision.CompareTag("Puchi"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
}
