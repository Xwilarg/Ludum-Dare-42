using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < -30f)
            Destroy(gameObject);
    }
}
