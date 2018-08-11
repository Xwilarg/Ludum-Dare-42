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
            GameObject go = Instantiate(characPrefab, new Vector2(Random.Range(-2f, 2f), 8f), Quaternion.identity);
            MyCharacter charac = go.GetComponent<MyCharacter>();
            charac.me = Character.basicCharacters[Random.Range(0, Character.basicCharacters.Length)];
            charac.descriptionPanel = descriptionPanel;
        }
    }
}
