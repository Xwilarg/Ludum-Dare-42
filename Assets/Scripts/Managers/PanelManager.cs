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

    public void AddPileCharacter(MyCharacter NetCharacter)
    {
        GameObject go = Instantiate(CharacterPanelPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        go.transform.SetParent(PilePanel.transform, false);
        go.transform.position = new Vector3(PanelList.Count * 100 + 30, PilePanel.transform.position.y + 50);
        go.GetComponentInChildren<Button>().onClick.AddListener(NetCharacter.DisplayDescriptionPanel);
        Text TextChild = go.GetComponentInChildren<Text>();
        TextChild.text = NetCharacter.me.name + System.Environment.NewLine + NetCharacter.me.weight.ToString();
        PanelList.Add(new MTuple<GameObject, MyCharacter>(go, NetCharacter));
    }

    public void DelPileCharacter(GameObject obj)
    {
        MTuple<GameObject, MyCharacter> tof = PanelList.Find(x => x.a == obj);

        PanelList.Remove(tof);
        tof.a.SetActive(false);
        tof.b.gameObject.transform.parent = null;
        Rigidbody2D rb = tof.b.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2(-15f, 8f), ForceMode2D.Impulse);
        rb.AddTorque(20f, ForceMode2D.Impulse);

        for (int i = 0; i < PanelList.Count; ++i)
        {
            PanelList[i].a.transform.position = new Vector3(i * 100 + 30, PanelList[i].a.transform.position.y);
        }
        PlayerCntl.speed += tof.b.me.weight;
    }
}
