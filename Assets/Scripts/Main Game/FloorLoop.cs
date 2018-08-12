using UnityEngine;

public class FloorLoop : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < -17)
            transform.Translate(new Vector2(35f, 0f));
    }
}
