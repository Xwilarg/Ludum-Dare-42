using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Bridge : MonoBehaviour
{
    [SerializeField]
    private Text lostText;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().didLost = true;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            lostText.gameObject.SetActive(true);
        }
    }
}
