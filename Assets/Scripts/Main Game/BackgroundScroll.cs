using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private const float speed = 4f;

    private void Update()
    {
        transform.Translate(new Vector2(0f, -speed * Time.deltaTime));
        if (transform.position.y < -7.5)
        {
            if (tag == "Character")
                Destroy(gameObject);
            else
                transform.Translate(new Vector2(0f, 15f));
        }
    }
}
