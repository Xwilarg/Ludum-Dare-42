using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    [SerializeField]
    GameObject LeftUpPanel;
    [SerializeField]
    GameObject RightUpPanel;
    [SerializeField]
    GameObject LeftDownPanel;
    [SerializeField]
    GameObject RightDownPanel;

    void Start ()
    {
        Text LUText = LeftUpPanel.GetComponentInChildren<Text>();
        Text RUText = RightUpPanel.GetComponentInChildren<Text>();
        Text LDText = LeftDownPanel.GetComponentInChildren<Text>();
        Text RDText = RightDownPanel.GetComponentInChildren<Text>();

        LUText.text = "Hi, as you might have been teased, well, it's the end of space and everything";
        RUText.text = "Well, sorry to bother you, but you might want to escape no ?";
        LDText.text = "AH ! Yes ! Obviously other \"peoples\" are trying to escape from \"it\" too, yes, it's alive.";
        RDText.text = "Run !";

        LeftUpPanel.SetActive(true);
        RightUpPanel.SetActive(false);
        LeftDownPanel.SetActive(false);
        RightDownPanel.SetActive(false);
    }

    private int display = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            switch (display)
            {
                case 0:
                    RightUpPanel.SetActive(true);
                    break;
                case 1:
                    LeftDownPanel.SetActive(true);
                    break;
                case 2:
                    RightDownPanel.SetActive(true);
                    break;
                default:
                    SceneManager.LoadScene("main");
                    break;

            }
            ++display;
        }
    }
}
