using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    private Text myText;

    // Use this for initialization

    private void Awake()
    {
        myText = GetComponent<Text>();
    }

    void Start () {

        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        myText.text = "Score : " + score;
	}



}
