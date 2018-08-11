using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private const float speed = 4f;

    private void Update()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));
        if (transform.position.x < -12)
        {
            if (tag == "Character")
                Destroy(gameObject);
            else
                transform.Translate(new Vector2(25f, 0f));
        }
    }
}
