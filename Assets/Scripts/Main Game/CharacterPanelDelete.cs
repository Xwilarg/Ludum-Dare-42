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
    [SerializeField]
    private GameObject lovePrefab;
    private GameObject Poutch;

    private TrapManager Tm;
    public MyCharacter me { set; private get; }
    private const float refTimer = 2f;
    private readonly Vector2 speakTimerRef = new Vector2(6f, 15f);
    private float speakTimer;
    private float timer;
    private PanelManager Pm;
    private float attackTimer;
    private PlayerController pc;
    private float speTimer;
    private SummonMini Sm;
    [SerializeField]
    private Image i;

    private void Start()
    {
        Poutch = GameObject.FindGameObjectWithTag("Beast");
        while (Poutch.transform.parent != null)
            Poutch = Poutch.transform.parent.gameObject;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        timer = -1f;
        Pm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PanelManager>();
        Tm = Pm.GetComponent<TrapManager>();
        Sm = Poutch.GetComponent<SummonMini>();
        StartTimer(me.me.entryLine);
        ResetSpeak();
        attackTimer = me.me.cooldown;
        ResetCooldown();
        if (me.me.classe == Character.Classe.Clone)
            cooldownPanel.gameObject.SetActive(false);
        speTimer = -1.5f;
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
        setWhite();
    }

    private void setWhite()
    {
        i.color = Color.white;
    }

    private void setGreen()
    {
        i.color = Color.green;
    }

    private void Update()
    {
        if ((me.me.classe == Character.Classe.Sport && pc.perso != PlayerController.Perso.Rinna)
            || (me.me.classe == Character.Classe.Medic && pc.perso == PlayerController.Perso.Rinna)
            || me.me.classe == Character.Classe.Clone)
        {
            if (attackTimer != 0f)
            {
                attackTimer = 0f;
                cooldownPanel.localScale = new Vector3(1f, attackTimer / 0.1f, 0f);
            }
            return;
        }
        attackTimer -= Time.deltaTime;
        speTimer -= Time.deltaTime;
        if (attackTimer < 0f && cooldownPanel.gameObject.activeInHierarchy)
        {
            cooldownPanel.gameObject.SetActive(false);
            if (me.me.classe == Character.Classe.Medic || me.me.classe == Character.Classe.Sport)
            {
                if (pc.Heal())
                {
                    StartTimer(me.me.ability);
                    ResetCooldown();
                }
                else
                    cooldownPanel.gameObject.SetActive(true);
            }
            else if (me.me.classe == Character.Classe.Fearful)
            {
                StartTimer(me.me.ability);
                setGreen();
                speTimer = 5f;
                pc.speed += 20f;
            }
            else if (me.me.classe == Character.Classe.Drunk)
            {
                StartTimer(me.me.ability);
                if (Random.Range(0f, 1f) < 0.5f)
                {
                    speTimer = 5f;
                    pc.speed -= 10f;
                    setGreen();

                }
                else
                {
                    pc.Heal();
                    ResetCooldown();
                }
            }
            else if (me.me.classe == Character.Classe.Tsundere)
            {
                // Don't add StartTimer to not spam
                GameObject go = Instantiate(lovePrefab, me.transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 30f, ForceMode2D.Impulse);
                ResetCooldown();
            }
            else if (me.me.classe == Character.Classe.Narcissistic)
            {
                StartTimer(me.me.ability);
                speTimer = 5f;
                Tm.refTimer = new Vector2(-0.25f, 4f);
                setGreen();
            }
            else if (me.me.classe == Character.Classe.Lost)
            {
                if (pc.CanTakeDamage() == false)
                {
                    DeleteMe(gameObject);
                }
                else
                {
                    pc.TakeDamage();
                    StartTimer(me.me.ability);
                    speTimer = 5f;
                    Sm.spawning = false;
                    Tm.spawning = false;
                    setGreen();
                }
            }
            else if (me.me.classe == Character.Classe.Vocaloid)
            {
                StartTimer(me.me.ability);
                speTimer = 5f;
                pc.cloneFireRate = 0.7f;
                setGreen();
            }
            else if (me.me.classe == Character.Classe.Sister)
            {
                StartTimer(me.me.ability);
                speTimer = 5f;
                pc.canTakeDamage = false;
                setGreen();
            }
            else if (me.me.classe == Character.Classe.Dead)
            {
                StartTimer(me.me.ability);
                ResetCooldown();
                pc.score += 200f;
            }
        }
        if (speTimer < 0f && speTimer > -1f)
        {
            if (me.me.classe == Character.Classe.Fearful)
            {
                pc.speed -= 20f;
                ResetCooldown();
            }
            else if (me.me.classe == Character.Classe.Drunk)
            {
                pc.speed += 10f;
                ResetCooldown();
            }
            else if (me.me.classe == Character.Classe.Narcissistic)
            {
                Tm.refTimer = new Vector2(0.5f, 2f);
                ResetCooldown();
            }
            else if (me.me.classe == Character.Classe.Lost)
            {
                Sm.spawning = true;
                Tm.spawning = true;
                Tm.refTimer = new Vector2(0.5f, 2f);
                ResetCooldown();
            }
            else if (me.me.classe == Character.Classe.Vocaloid)
            {
                pc.cloneFireRate = 1f;
                ResetCooldown();
            }
            else if (me.me.classe == Character.Classe.Sister)
            {
                pc.canTakeDamage = true;
                ResetCooldown();
            }
            speTimer = -1.5f;
        }
        else if (me.me.cooldown != 0f)
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
