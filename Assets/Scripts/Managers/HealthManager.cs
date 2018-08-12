using UnityEngine;

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
            depas = -newVal;
            index++;
            if (index < bars.Length)
                bars[index].sizeDelta = new Vector2(newVal, bars[0].sizeDelta.y);
        }
    }
}
