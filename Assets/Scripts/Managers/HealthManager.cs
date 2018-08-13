using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public RectTransform[] bars;
    private int index;
    private PlayerController pc;
    private Almanac Al;

    private void Start()
    {
        index = 0;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Al = GameObject.FindGameObjectWithTag("Almanac").GetComponent<Almanac>();
    }

    public void TakeDamage(float value)
    {
        if (index >= bars.Length)
            return;
        pc.score += value;
        float newVal = bars[index].sizeDelta.x - value;
        float depas = 0f;
        bars[index].sizeDelta = new Vector2(newVal, bars[0].sizeDelta.y);
        if (newVal < 0)
        {
            index++;
            if (index < bars.Length)
            {
                depas = bars[index].sizeDelta.x + newVal;
                bars[index].sizeDelta = new Vector2(depas, bars[0].sizeDelta.y);
            }
        }
        if (index >= bars.Length)
        {
            Al.score = pc.score;
            SceneManager.LoadScene("Win");
        }
    }
}
