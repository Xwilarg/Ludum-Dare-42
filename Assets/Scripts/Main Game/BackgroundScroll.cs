using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private bool invert;
    private const float speed = 4f;

    private void Update()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime * ((invert) ? (-1f) : (1f)), 0f));
        if (transform.position.x < -12)
        {
            if (tag == "Character")
                Destroy(gameObject);
            else
                transform.Translate(new Vector2(25f, 0f));
        }
    }
}
