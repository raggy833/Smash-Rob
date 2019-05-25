using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject Player1, Player2;
    public Transform startPos1, startPos2;

    //public static int p1_lives = 3;
    //public static int p2_lives = 3;
    //public Text p1_livesText;
    //public Text p2_livesText;
    //public GameObject respawnPlat;

    //private string p1_livesCount;
    //private string p2_livesCount;
    private bool spawnedPlayers = false;

    void Awake(){
	StartPositions();    
    }

    void Start () {
        //UpdateLives();
    }
	
	void Update () {
        //UpdateLives();

        if (!spawnedPlayers) {
            StartPositions();
        }
    }

    public void StartPositions() {
        // Swapns players
        //TO DO: change player character depending on selected character
        GameObject PlayerOne = Instantiate(Player1, startPos1.position, Quaternion.identity) as GameObject;
        GameObject PlayerTwo = Instantiate(Player2, startPos2.position, Quaternion.Euler(0, 180, 0)) as GameObject;
        spawnedPlayers = true;
        Debug.Log("Spawned Players");
    }

    //public void UpdateLives()
    //{
    //    p1_livesCount = p1_lives.ToString();
    //    p1_livesText.text = p1_livesCount;

    //    p2_livesCount = p2_lives.ToString();
    //    p2_livesText.text = p2_livesCount;

    //}
}
