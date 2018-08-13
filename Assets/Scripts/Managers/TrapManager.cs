using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trapPrefab;
    [SerializeField]
    private GameObject player;

    private readonly Vector2 refTimer = new Vector2(0.5f, 2f);
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
            Instantiate(trapPrefab, new Vector2(15f, Random.Range(-1.5f, 2f)), Quaternion.identity);
        }
    }
}
