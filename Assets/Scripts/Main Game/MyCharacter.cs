using UnityEngine;
using UnityEngine.UI;

public class MyCharacter : MonoBehaviour
{
    public Character me { set; get; }
    private GameObject descriptionPanel;

    public void SetDescriptionPanel(GameObject go)
    {
        descriptionPanel = go;
        descriptionPanel.GetComponentInChildren<Button>().onClick.AddListener(ResetWordTime);
    }

    private void OnMouseDown()
    {
        descriptionPanel.SetActive(true);
        Time.timeScale = 0.1f;
    }

    private void ResetWordTime()
    {
        Time.timeScale = 1f;
    }
}
