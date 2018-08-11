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
    private float timer;
    private PanelManager Pm;

    private void Start()
    {
        timer = -1f;
        Pm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PanelManager>();
        StartTimer(me.me.entryLine);
    }

    public void StartTimer(string text)
    {
        timer = refTimer;
        textSpeak.text = text;
        panelSpeak.SetActive(true);
    }

    private void Update()
    {
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
