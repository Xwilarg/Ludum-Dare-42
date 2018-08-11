using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject CharacterPanelPrefab;
    [SerializeField]
    private GameObject PilePanel;
    [SerializeField]
    private GameObject StatsPanel;

    private List<GameObject> PanelList = new List<GameObject>();

    public void AddPileCharacter(Character NetCharacter)
    {
        GameObject go = Instantiate(CharacterPanelPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        go.transform.SetParent(PilePanel.transform, false);
        go.transform.position = new Vector3(PanelList.Count * 100 + 30, PilePanel.transform.position.y + 50);
        //Button ButtonChild = go.GetComponent<Button>();
        Text TextChild = go.GetComponentInChildren<Text>();
        TextChild.text = NetCharacter.name + System.Environment.NewLine + NetCharacter.weight.ToString();
        PanelList.Add(go);
    }

    public void DelPileCharacter(GameObject obj)
    {
        PanelList.Remove(obj);
        obj.SetActive(false);

        for (int i = 0; i < PanelList.Count; ++i)
        {
            PanelList[i].transform.position = new Vector3(i * 100 + 30, PanelList[i].transform.position.y);
        }
    }
}
