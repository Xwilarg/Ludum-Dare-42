using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    private Almanac al;

    private void Start()
    {
        al = GameObject.FindGameObjectWithTag("Almanac").GetComponent<Almanac>();
    }

    public void Select(int i)
    {
        al.SetPerso((PlayerController.Perso)i);
    }
}
