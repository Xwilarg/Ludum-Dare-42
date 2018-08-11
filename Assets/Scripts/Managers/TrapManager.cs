using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trapPrefab;
    [SerializeField]

    private readonly Vector2 refTimer = new Vector2(2f, 4f);
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
            Instantiate(trapPrefab, new Vector2(10f, Random.Range(-0.3f, 0.5f)), Quaternion.identity);
        }
    }
}
