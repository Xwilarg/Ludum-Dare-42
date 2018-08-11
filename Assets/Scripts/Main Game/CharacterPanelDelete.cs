using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelDelete : MonoBehaviour {

    [SerializeField]
    private GameObject panelSpeak;
    [SerializeField]
    private Text textSpeak;
    public MyCharacter me { set; private get; }

    private const float refTimer = 2f;
    private readonly Vector2 speakTimerRef = new Vector2(6f, 15f);
    private float speakTimer;
    private float timer;
    private PanelManager Pm;

    private void Start()
    {
        timer = -1f;
        Pm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PanelManager>();
        StartTimer(me.me.entryLine);
        ResetSpeak();
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

    private void Update()
    {
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
