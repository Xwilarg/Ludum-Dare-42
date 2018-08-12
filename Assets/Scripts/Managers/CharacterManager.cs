using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characPrefab;
    [SerializeField]
    private GameObject descriptionPanel;
    [SerializeField]
    private Text nameText, description1;
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
            if (Character.basicCharacters.Count == 0)
                return;
            GameObject go = Instantiate(characPrefab, new Vector2(15f, Random.Range(3f, 4f)), Quaternion.identity);
            MyCharacter charac = go.GetComponent<MyCharacter>();
            if (Random.Range(0, 10) == 0)
                charac.me = Character.basicCharacters[Random.Range(0, Character.basicCharacters.Count)];
            else
            {
                charac.me = Character.clone;
                charac.me.weapon = Weapon.Weapons[Random.Range(0, Weapon.Weapons.Length)];
            }
            Character.basicCharacters.Remove(charac.me);
            go.GetComponent<Animator>().runtimeAnimatorController = charac.me.hanging;
            charac.SetDescriptionPanel(descriptionPanel, nameText, description1, image);
        }
    }
}
