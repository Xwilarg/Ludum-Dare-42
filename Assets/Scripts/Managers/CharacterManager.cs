using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characPrefab;
    [SerializeField]
    private GameObject descriptionPanel;

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
            GameObject go = Instantiate(characPrefab, new Vector2(10f, Random.Range(2f, 4f)), Quaternion.Euler(new Vector3(0f, 0f, 180f)));
            MyCharacter charac = go.GetComponent<MyCharacter>();
            charac.me = Character.basicCharacters[Random.Range(0, Character.basicCharacters.Length)];
            charac.SetDescriptionPanel(descriptionPanel);
        }
    }
}
