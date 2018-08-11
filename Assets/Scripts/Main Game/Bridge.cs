using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bridge : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.GetComponent<PlayerController>().isJumping)
            collision.GetComponent<PlayerController>().Loose();
    }
}
