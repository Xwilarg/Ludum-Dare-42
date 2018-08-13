using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct MTuple<T1, T2>
{
    public MTuple(T1 a, T2 b)
    {
        this.a = a;
        this.b = b;
    }
    public T1 a;
    public T2 b;
}

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject CharacterPanelPrefab;
    [SerializeField]
    private GameObject PilePanel;
    [SerializeField]
    private GameObject StatsPanel;

    private GameObject PlayerCntlObj;
    private PlayerController PlayerCntl;
    public List<MTuple<GameObject, MyCharacter>> PanelList = new List<MTuple<GameObject, MyCharacter>>();

    public void Start()
    {
        PlayerCntlObj = GameObject.FindGameObjectWithTag("Player");
        PlayerCntl = PlayerCntlObj.GetComponent<PlayerController>();
    }

    private readonly KeyCode[] AlphaKeys = new KeyCode[] {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0
    };

    private readonly KeyCode[] NumKeys = new KeyCode[] {
        KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9, KeyCode.Keypad0
    };

    private void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if ((Input.GetKeyDown(AlphaKeys[i]) || Input.GetKeyDown(NumKeys[i])) && PanelList.Count > i)
            {
                PanelList[i].a.GetComponent<CharacterPanelDelete>().DeleteMe(PanelList[i].a);
            }
        }
    }

    public void AddPileCharacter(MyCharacter NetCharacter)
    {
        GameObject go = Instantiate(CharacterPanelPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        go.transform.SetParent(PilePanel.transform, false);
        //go.GetComponentInChildren<Button>().onClick.AddListener(NetCharacter.DisplayDescriptionPanel);
        go.GetComponent<CharacterPanelDelete>().me = NetCharacter;
        Text TextChild = go.GetComponentInChildren<Text>();
        TextChild.text = NetCharacter.me.name + System.Environment.NewLine + (NetCharacter.me.weight / Character.WeightMultiplicator).ToString() + " kg";
        PanelList.Add(new MTuple<GameObject, MyCharacter>(go, NetCharacter));
    }

    public IEnumerator DelPileCharacter(GameObject obj)
    {
        MTuple<GameObject, MyCharacter> tof = PanelList.Find(x => x.a == obj);
        if (tof.b.me.classe == Character.Classe.Sport)
            PlayerCntl.airControl = false;
        tof.a.GetComponent<CharacterPanelDelete>().StartTimer(tof.b.me.exitLine);
        yield return new WaitForSeconds(1);
        PlayerCntl.score -= tof.b.me.weight / Character.WeightMultiplicator;
        PanelList.Remove(tof);
        tof.a.SetActive(false);
        tof.b.gameObject.transform.parent = null;
        Rigidbody2D rb = tof.b.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2(-15f, 8f), ForceMode2D.Impulse);
        rb.AddTorque(20f, ForceMode2D.Impulse);

        for (int i = 0; i < PanelList.Count; ++i)
        {
            PanelList[i].b.transform.position = PlayerCntlObj.transform.position + new Vector3(0f, .8f) * (1 + i);
            PanelList[i].a.transform.position = new Vector3(i * 100 + 30, PanelList[i].a.transform.position.y);
            PanelList[i].b.GetComponent<SpriteRenderer>().sortingOrder = 999 - i;
        }
        PlayerCntl.speed += tof.b.me.weight;
    }
}
