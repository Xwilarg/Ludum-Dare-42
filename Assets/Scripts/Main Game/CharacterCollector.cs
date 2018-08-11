using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterCollector : MonoBehaviour
{
    private PlayerController master;
    [SerializeField]
    private PanelManager Pm;

    private void Start()
    {
        master = transform.parent.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            collision.GetComponent<BackgroundScroll>().enabled = false;
            collision.transform.GetChild(0).gameObject.SetActive(false);
            collision.GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<Animator>().enabled = false;
            collision.transform.parent = transform;
            collision.transform.position = transform.position + new Vector3(0f, -.2f) * (1 + Pm.PanelList.Count);
            MyCharacter c = collision.GetComponent<MyCharacter>();
            collision.GetComponent<SpriteRenderer>().sprite = c.me.sitDown;
            Pm.AddPileCharacter(c);
            master.speed -= c.me.weight;
            if (master.speed < 0.1f)
                master.speed = 0.1f;
        }
    }
}
