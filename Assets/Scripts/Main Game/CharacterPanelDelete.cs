using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelDelete : MonoBehaviour
{
    [SerializeField]
    private GameObject panelSpeak;
    [SerializeField]
    private Text textSpeak;
    [SerializeField]
    private RectTransform cooldownPanel;
    public MyCharacter me { set; private get; }

    private const float refTimer = 2f;
    private readonly Vector2 speakTimerRef = new Vector2(6f, 15f);
    private float speakTimer;
    private float timer;
    private PanelManager Pm;
    private float attackTimer;
    private PlayerController pc;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        timer = -1f;
        Pm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PanelManager>();
        StartTimer(me.me.entryLine);
        ResetSpeak();
        attackTimer = me.me.cooldown;
        if (me.me.classe == Character.Classe.Clone)
            cooldownPanel.gameObject.SetActive(false);
    }

    private void ResetSpeak()
    {
        speakTimer = Random.Range(speakTimerRef.x, speakTimerRef.y);
    }

    public void StartTimer(string text)
    {
        timer = refTimer;
        textSpeak.text = text;
        panelSpeak.SetActive(true);
    }

    private void ResetCooldown()
    {
        attackTimer = me.me.cooldown;
        cooldownPanel.localScale = new Vector3(1f, 1f, 0f);
        cooldownPanel.gameObject.SetActive(true);
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0f)
        {
            cooldownPanel.gameObject.SetActive(false);
            if (me.me.classe == Character.Classe.Medic)
            {
                if (pc.Heal())
                    ResetCooldown();
            }
        }
        else
            cooldownPanel.localScale = new Vector3(1f, attackTimer / me.me.cooldown, 0f);
        speakTimer -= Time.deltaTime;
        if (speakTimer < 0f)
        {
            StartTimer(me.me.lines[Random.Range(0, me.me.lines.Length)]);
            ResetSpeak();
        }
        if (timer > 0f)
            timer -= Time.deltaTime;
        else if (timer > -1f)
        {
            timer = -1f;
            panelSpeak.SetActive(false);
        }
    }

    public void DeleteMe(GameObject obj)
    {
        StartCoroutine(Pm.DelPileCharacter(obj));
    }
}
