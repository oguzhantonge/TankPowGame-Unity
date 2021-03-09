using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;
    private int score;

    private Text scoreText;
    private Text TotalCoinsText;

    private bool IsMainMenuActive = true;

    [SerializeField]
    private GameObject pausePanel;

    private bool gameStop = false;
    void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayerPrefs.GetInt("TotalCoins");
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE : " + score;
        PauseGame();

    }

    public int SCORE
    {
        get { return score; }
        set { score = value; }
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            print("hello");
            pausePanel.SetActive(true);
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            pausePanel.SetActive(false);
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

}
