using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WinRecap : MonoBehaviour
{
    private WinCharacters win;
    private Text text;

    private void Start()
    {
        win = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WinCharacters>();
        text.text = "You sucessfully managed to escape the end of everything by going in a wormhole, but now everything is to rebuild..." + System.Environment.NewLine + System.Environment.NewLine;
        if (win.survivors.Count == 0)
            text.text += "Sadly there was nobody to help you on that task so you just ended up dying alone in a small hole, you pathetic piece of garbage. *cough* Anyway, you should try playing again by saving some people.";
        else if (win.survivors.Count == 1)
            text.text += win.survivors[0].winAlone;
        else if (win.survivors.Count >= 3 && win.survivors.All(x => x.sexe == Character.Sexe.Female))
            text.text += "You didn't managed to create a new world but at least you got a beautiful harem until your death, and as I male developer, I must say it: Congratulation!";
        else
            text.text += "You managed to recreate a new civilization, life was hard on it but at least you managed to save the mankind to the end of everything.";
    }
}
