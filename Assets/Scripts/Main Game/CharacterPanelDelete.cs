using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanelDelete : MonoBehaviour {

    private PanelManager Pm;

    private void Start()
    {
        Pm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PanelManager>();
    }

    public void DeleteMe(GameObject obj)
    {
        Pm.DelPileCharacter(obj);
    }
}
