using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Use this for initialization
    private Almanac Al;
    private Text text;

	void Start () {
        Al = GameObject.FindGameObjectWithTag("Almanac").GetComponent<Almanac>();
        gameObject.GetComponent<Text>().text = "Your final score: <b>" + Al.score.ToString() + "</b>" + System.Environment.NewLine + System.Environment.NewLine + gameObject.GetComponent<Text>().text;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
