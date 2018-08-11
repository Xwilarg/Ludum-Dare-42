using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characPrefab;
    [SerializeField]
    private GameObject descriptionPanel;
    [SerializeField]
    private Text nameText, description1, description2, description3;
    [SerializeField]
    private Image image;

    private readonly Vector2 refTimer = new Vector2(3f, 5f);
    private float timer;

    private void Start()
    {
        timer = Random.Range(refTimer.x, refTimer.y);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = Random.Range(refTimer.x, refTimer.y);
            GameObject go = Instantiate(characPrefab, new Vector2(10f, Random.Range(3f, 4f)), Quaternion.Euler(new Vector3(0f, 0f, 180f)));
            MyCharacter charac = go.GetComponent<MyCharacter>();
            characPrefab.GetComponent<Animator>().runtimeAnimatorController = charac.me.hanging;
            charac.me = Character.basicCharacters[Random.Range(0, Character.basicCharacters.Length)];
            charac.SetDescriptionPanel(descriptionPanel, nameText, description1, description2, description3, image);
        }
    }
}
