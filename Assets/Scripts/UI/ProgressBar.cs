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
        if (!player.didLost)
            playerUI.Translate(new Vector3(player.speed / 6000f, 0f, 0f));
    }
}
