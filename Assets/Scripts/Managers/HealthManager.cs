using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public RectTransform[] bars;
    private int index;

    private void Start()
    {
        index = 0;
    }

    public void TakeDamage(float value)
    {
        if (index >= bars.Length)
            return;
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
            SceneManager.LoadScene("Win");
    }
}
