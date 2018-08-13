using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Almanac : MonoBehaviour
{
    private List<Character> saved;
    public float score;

    public void AddSaved(Character c)
    {
        if (!saved.Contains(c))
            saved.Add(c);
    }

    private void Start()
    {
        saved = new List<Character>();
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
