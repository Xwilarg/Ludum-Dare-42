using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField]
    private GameObject starPrefab;
    [SerializeField]
    private Sprite[] stars;

    private readonly Vector2 refTimer = new Vector2(0.001f, 0.1f);
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
            GameObject go = Instantiate(starPrefab, new Vector2(15f, Random.Range(-5f, 5f)), Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sprite = stars[Random.Range(0, stars.Length)];
            go.transform.localScale = new Vector2(.1f, .1f);
            go.GetComponent<BackgroundScroll>().speed = Random.Range(0.1f, 1f);
        }
    }
}
