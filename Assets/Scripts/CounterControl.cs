using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterControl : MonoBehaviour {

    public Text stageCountdown;
    public int countdownNum;

    private int countdownNumOri = 3;

    // Use this for initialization
    void Start() {
        countdownNum = countdownNumOri;
    }

    // Update is called once per frame
    void Update() {
        if(countdownNum == 0) {
            GameManager.gameStarted = true;
            gameObject.SetActive(false);
            countdownNum = countdownNumOri;
        }
    }

    public void Countdown() {
        countdownNum--;
        stageCountdown.text = countdownNum.ToString();
    }
}
