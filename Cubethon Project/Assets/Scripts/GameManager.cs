using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    GameObject player;
    public GameObject completeLevelUI;
    public bool instantReplay = false;

    private void OnEnable()
    {
        PlayerCollision.OnHurtObstacle += EndGame;
    }
    private void OnDisable()
    {
        PlayerCollision.OnHurtObstacle -= EndGame;
    }

    void Start()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.gameObject;

        if (CommandLog.commands.Count > 0)
        {
            instantReplay = true;
            restartDelay = Time.timeSinceLevelLoad;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (instantReplay)
        //{
        //    RunInstantReplay();
        //}
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
     
    public void EndGame(Collision collisionInfo)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        PlayerCollision.OnHurtObstacle -= EndGame;
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void RunInstantReplay()
    {
        if (CommandLog.commands.Count == 0)
        {
            instantReplay = false;
            return;
        }
        Command command = CommandLog.commands.Peek();
        if (Time.timeSinceLevelLoad >= command.timestamp) // + replayStartTime)
        {
            Debug.Log("Replay");
            command = CommandLog.commands.Dequeue();
            command._player = player.GetComponent<Rigidbody>(); 
            Invoker invoker = new Invoker();
            invoker.disableLog = true; // make new invoker
            invoker.SetCommand(command); // making it move
            invoker.ExecuteCommand(command);
        }
    }
}
