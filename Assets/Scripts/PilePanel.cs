using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilePanel : MonoBehaviour {

    [SerializeField]
    private GameObject Panel;

    private List<GameObject> PanelList;
    private GameObject ParentPanel;

    private void Start()
    {
        ParentPanel = GameObject.Find("pile_panel");
    }

    public void AddPileCharacter(Character NetCharacter)
    {
        GameObject go = Instantiate(ParentPanel, new Vector3(20, 20, 20), Quaternion.identity);
    }
}