using UnityEngine;
using UnityEngine.UI;

public class MyCharacter : MonoBehaviour
{
    public Character me { set; get; }
    private GameObject descriptionPanel;
    private Text nameText, description1, description2, description3;
    private Image image;

    public void SetDescriptionPanel(GameObject go, Text nameText, Text description1, Text description2, Text description3, Image image)
    {
        this.nameText = nameText;
        this.description1 = description1;
        this.description2 = description2;
        this.description3 = description3;
        this.image = image;
        descriptionPanel = go;
        descriptionPanel.GetComponentInChildren<Button>().onClick.AddListener(ResetWordTime);
    }

    private void OnMouseDown()
    {
        DisplayDescriptionPanelBullet();
    }

    public void DisplayDescriptionPanel()
    {
        descriptionPanel.SetActive(true);
        nameText.text = me.name;
        description1.text = me.description1;
    }

    public void DisplayDescriptionPanelBullet()
    {
        DisplayDescriptionPanel();
        Time.timeScale = 0.1f;
    }

    private void ResetWordTime()
    {
        Time.timeScale = 1f;
    }
}
