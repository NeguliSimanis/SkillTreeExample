using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool gameStarted = false;
    public static GameManager instance;
    private PlayerController playerController;
    private UserInterfaceManager userInterfaceManager;

    private void Awake()
    {
        if (PlayerStats.current == null)
        {
            PlayerStats.current = new PlayerStats();
            DontDestroyOnLoad(this);
        }

        if (GameManager.instance == null)
            GameManager.instance = this;
        else
            Destroy(this.gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetGame();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void ResetGame()
    {
        PlayerStats.current.Reset();
        gameStarted = false;
        userInterfaceManager = gameObject.GetComponent<UserInterfaceManager>();
        userInterfaceManager.InitializeManager();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerStats.current.currentLives > 0
            && !gameStarted)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        userInterfaceManager.HideMainMenu();
        playerController.StartGame();
        gameStarted = true;
    }
    public void EndGame()
    {
        if (!gameStarted)
            return;
        gameStarted = false;
        userInterfaceManager.ShowEndGameUI();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
