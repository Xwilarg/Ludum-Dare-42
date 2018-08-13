using UnityEngine;
using UnityEngine.UI;

public class MyCharacter : MonoBehaviour
{
    public Character me { set; get; }
    private GameObject descriptionPanel;
    private Text nameText, description1, description2, description3;
    private Image image;
    private PlayerController pc;
    public bool taken { set; private get; }
    private Transform beast;
    private float timer;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        taken = false;
        if (me.weapon == null)
            return;
        timer = me.weapon.fireRate;
        beast = GameObject.FindGameObjectWithTag("Beast").transform;
        while (beast.parent != null)
            beast = beast.parent;
    }

    public void Update()
    {
        if (!taken || me.weapon == null)
            return;
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = me.weapon.fireRate * pc.cloneFireRate;
            GameObject go = Instantiate(pc.bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb2d = go.GetComponent<Rigidbody2D>();
            float angle = Random.Range(1f, 5f);
            rb2d.AddForce(new Vector2(-30f, angle), ForceMode2D.Impulse);
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
