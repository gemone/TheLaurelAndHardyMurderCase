﻿/* Yannick Renz
 * Cologne Game Lab
 * BA 1 - Ludic Game 2018 / 2019
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //I might add this script to GO Overlay at a later point
    
    private Text scoreText;
    private Collider2D exit;
    private Exit exitScript;

    public float score;
    public float scoreDecrease; //per second

    public float countdown;
    public Text countdownText;

	void Start () {
        exit = GameObject.Find("Exit").GetComponent<Collider2D>();
        exit.enabled = false;

        exitScript = GameObject.Find("/Exit").GetComponent<Exit>();

        if (countdown > 0)
        {
            exitScript.open = false;
            countdown += 1;
        }
        else
        {
            exit.enabled = true;
            exitScript.open = true;
        }

        scoreText = GameObject.Find("Overlay/Score").GetComponent<Text>();
        scoreText.text = "Viewers: " + score;
    }

	void Update () {


        //Score
        if (score > 0f) score -= scoreDecrease * Time.deltaTime;
        scoreText.text = "Viewers: " + score.ToString("f0");

        //Countdown
        if(countdown >= 10)
        {
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.Floor(countdown).ToString("f0");
        } else if(countdown > 0)
        {
            countdown -= Time.deltaTime;
            countdownText.text = (Mathf.Ceil(countdown*10) / 10).ToString("f1"); //lol idk
        } else if (exitScript.open == false)
        {
            exit.gameObject.GetComponent<AudioSource>().Play();
            exit.enabled = true;
            exitScript.open = true;
            countdownText.gameObject.SetActive(false);
        }

	}

    public void ChangeScore(float amount)
    {
        score += amount;
    }
}