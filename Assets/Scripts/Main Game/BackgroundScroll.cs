using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private bool invert;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        transform.Translate(new Vector2(-((player.speed / 50f)) * Time.deltaTime * ((invert) ? (-1f) : (1f)), 0f));
        if (transform.position.x < -12)
        {
            if (tag == "Character")
                Destroy(gameObject);
            else
                transform.Translate(new Vector2(25f, 0f));
        }
    }
}
