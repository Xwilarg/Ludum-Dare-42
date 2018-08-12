using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private bool invert;
    private PlayerController player;

    public float speed { set; private get; }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        speed = 1f;
    }

    private void Update()
    {
        transform.Translate(new Vector2(-((player.speed / 50f)) * Time.deltaTime * ((invert) ? (-1f) : (1f)) * speed, 0f));
        if (transform.position.x < -17)
        {
            if (tag == "Character" || tag == "Trap")
                Destroy(gameObject);
            else
                transform.Translate(new Vector2(35f, 0f));
        }
    }
}
