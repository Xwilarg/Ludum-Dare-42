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
        float newVal = bars[0].sizeDelta.x - value;
        bars[0].sizeDelta = new Vector2(newVal, bars[0].sizeDelta.y);
    }
}
