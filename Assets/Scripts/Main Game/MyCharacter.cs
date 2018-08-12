using UnityEngine;
using UnityEngine.UI;

public class MyCharacter : MonoBehaviour
{
    public Character me { set; get; }
    private GameObject descriptionPanel;
    private Text nameText, description1, description2, description3;
    private Image image;
    private LineRenderer lr;
    private PlayerController pc;
    public bool taken { set; private get; }
    private float raycastTimer;

    private float timer;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        taken = false;
        lr = GetComponent<LineRenderer>();
        if (me.weapon == null)
            return;
        timer = me.weapon.fireRate;
    }

    public void Update()
    {
        if (!taken || me.weapon == null)
            return;
        timer -= Time.deltaTime;
        raycastTimer -= Time.deltaTime;
        if (raycastTimer < 0f)
            lr.enabled = false;
        if (timer < 0f)
        {
            timer = me.weapon.fireRate;
            if (me.weapon.type == Weapon.WeaponType.Raycast)
            {
                lr.enabled = true;
                raycastTimer = 0.03f;
                Vector2 dir = new Vector2(-1f, Random.Range(-me.weapon.deviation, me.weapon.deviation));
                int mask = System.Convert.ToInt32("11111111111111111111100111111011", 2);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 10f, mask);
                Debug.Log(hit.collider);
                lr.SetPosition(0, transform.position - new Vector3(0f, 0f, 1f));
                if (hit.collider != null)
                    lr.SetPosition(1, new Vector3(hit.point.x, hit.point.y, -1f));
                else
                    lr.SetPosition(1, new Vector3(dir.x, dir.y, 0f) * 100f - new Vector3(0f, 0f, 1f));
            }
            else
            {
                GameObject go = Instantiate(pc.bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 45f)));
                go.GetComponent<SpriteRenderer>().sprite = me.weapon.sprite;
                BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
                bc.isTrigger = true;
                go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, me.weapon.baseY) * me.weapon.velocity, ForceMode2D.Impulse);
            }
        }
    }

    public void SetDescriptionPanel(GameObject go, Text nameText, Text description1, Image image)
    {
        this.nameText = nameText;
        this.description1 = description1;
        this.image = image;
        descriptionPanel = go;
        descriptionPanel.GetComponentInChildren<Button>().onClick.AddListener(ResetWordTime);
    }

    private void OnMouseDown()
    {
        DisplayDescriptionPanelBullet();
    }

    public void DisplayDescriptionPanel()
    {
        descriptionPanel.SetActive(true);
        nameText.text = me.name;
        description1.text = me.description1;
    }

    public void DisplayDescriptionPanelBullet()
    {
        DisplayDescriptionPanel();
        Time.timeScale = 0.1f;
    }

    private void ResetWordTime()
    {
        Time.timeScale = 1f;
    }
}
