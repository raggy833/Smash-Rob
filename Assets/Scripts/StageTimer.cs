using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTimer : MonoBehaviour {

    public Text counterText;
    public float gameTimer = 180;

    private float seconds, minutes;

    // Use this for initialization
    void Start() {
        minutes = (int)(gameTimer / 60f);
        seconds = (int)(gameTimer % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.gameStarted){
            StartStageTimer();

        }
    }

    public void StartStageTimer(){

        // add static bool for level finish
        if (GameManager.gameStarted) {
            gameTimer -= Time.deltaTime;
            minutes = (int)(gameTimer / 60f);
            seconds = (int)(gameTimer % 60f);
            counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        }
    }
}
