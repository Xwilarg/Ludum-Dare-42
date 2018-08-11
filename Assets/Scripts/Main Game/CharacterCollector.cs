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
            if (Pm.PanelList.Count == 0)
            {
                collision.transform.parent = transform;
                collision.transform.position = transform.position + new Vector3(0f, -.2f);
            }
            else
            {
                MyCharacter charac = Pm.PanelList[Pm.PanelList.Count - 1].b;
                collision.transform.parent = charac.transform;
                collision.transform.position = charac.transform.position + new Vector3(0f, -.2f);
            }
            MyCharacter c = collision.GetComponent<MyCharacter>();
            Pm.AddPileCharacter(c);
            master.speed -= c.me.weight;
            if (master.speed < 0.1f)
                master.speed = 0.1f;
        }
    }
}
