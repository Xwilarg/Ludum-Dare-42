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
            if (master.followers.Count == 0)
            {
                collision.transform.parent = transform;
                collision.transform.position = transform.position + new Vector3(0f, -.2f);
            }
            else
            {
                MyCharacter charac = master.followers[master.followers.Count - 1];
                collision.transform.parent = charac.transform;
                collision.transform.position = charac.transform.position + new Vector3(0f, -.2f);
            }
            MyCharacter c = collision.GetComponent<MyCharacter>();
            master.followers.Add(c);
            Pm.AddPileCharacter(c.me);
            master.speed -= c.me.weight;
        }
    }
}
