using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    private PlayerController player;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private RectTransform playerUI, enemyUI;
    private PanelManager pm;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PanelManager>();
    }

    private void Update()
    {
        if (!player.didLost)
        {
            playerUI.Translate(new Vector3(player.speed / 6000f, 0f, 0f));
            enemyUI.localPosition = new Vector2(playerUI.localPosition.x - (player.transform.position.x - enemy.transform.position.x), enemyUI.localPosition.y);
            if (playerUI.localPosition.x >= 120f)
            {
                GameObject go = new GameObject("WinInfos", typeof(WinCharacters));
                DontDestroyOnLoad(go);
                go.tag = "GameManager";
                go.GetComponent<WinCharacters>().survivors = pm.PanelList.Select(x => x.b.me).ToList();
                SceneManager.LoadScene("Win");
            }
        }
    }
}
    