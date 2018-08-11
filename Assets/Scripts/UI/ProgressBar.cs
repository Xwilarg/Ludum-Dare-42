using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    private PlayerController player;
    [SerializeField]
    private RectTransform playerUI;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        playerUI.Translate(new Vector3(0f, player.speed / 3000f, 0f));
    }
}
