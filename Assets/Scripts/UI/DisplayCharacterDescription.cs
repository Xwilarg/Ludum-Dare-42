using UnityEngine;
using UnityEngine.UI;

public class DisplayCharacterDescription : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Text nameTxt, descTxt;

    private string FormatDesc(Character c)
    {
        return (c.description1 + System.Environment.NewLine + System.Environment.NewLine +
            "Weight: " + c.weight + "kg, Height: " + c.height + " cm, Age: " + c.age + System.Environment.NewLine + System.Environment.NewLine +
            "Special Ability: " + c.abilityDescription);
    }

    private void ShowCharac(Character c)
    {
        panel.SetActive(true);
        nameTxt.text = c.name;
        descTxt.text = FormatDesc(c);
    }

    public void ShowTsun()
    {
        ShowCharac(Character.tsundere);
    }

    public void ShowDrunk()
    {
        ShowCharac(Character.drunkMan);
    }

    public void ShowFearful()
    {
        ShowCharac(Character.fearful);
    }

    public void ShowSister()
    {
        ShowCharac(Character.LittleSister);
    }

    public void ShowSport()
    {
        ShowCharac(Character.SportGirl);
    }

    public void ShowNar()
    {
        ShowCharac(Character.Narcissistic);
    }

    public void ShowDead()
    {
        ShowCharac(Character.DeadBody);
    }

    public void ShowMedic()
    {
        ShowCharac(Character.Medic);
    }

    public void ShowVocaloid()
    {
        ShowCharac(Character.Vocaloid);
    }
}
