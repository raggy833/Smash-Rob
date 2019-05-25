using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    //public GameObject Player1, Player2;
    //public Transform startPos1, startPos2;
    public static string sceneName;

    private bool p1_lost, p2_lost;
    private Scene currentScene;


    //private bool spawnedPlayers = false;

    public static bool gameStarted = false;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
    }

    void Start () {
        DontDestroyOnLoad(gameObject);
        p1_lost = false;
        p2_lost = false;
	}

    // Update is called once per frame
    void Update() {
        //CheckForWinner();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        //if (!spawnedPlayers && sceneName == "BattleStage") {
        //    StartPositions();
        //}
    }

    //public void StartPositions() {
    //    GameObject PlayerOne = Instantiate(Player1, startPos1.position, Quaternion.identity) as GameObject;
    //    GameObject PlayerTwo = Instantiate(Player2, startPos2.position, Quaternion.Euler(0, 180, 0)) as GameObject;
    //    spawnedPlayers = true;
    //    Debug.Log("Spawned Players");
    //}

    public void SelectedCharacter(bool selectedCha) {

    }
   
    public void StartStage() {
        gameStarted = true;
    }

    //public void CheckForWinner() {
    //    if(LevelManager.p1_lives == 0) {
    //        Debug.Log("Player 1 lost");
            
    //    }
    //    if(LevelManager.p2_lives == 0) {
    //        Debug.Log("Player 2 lost");

    //    }
    //}

    public void BackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
        
}
