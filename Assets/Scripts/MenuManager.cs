using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private bool isMainMenuTrue = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalCoins();


    }


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    void TotalCoins()
    {
        if (isMainMenuTrue) {
        GameObject.Find("TotalCoinsText").GetComponent<Text>().text = "Total Coins : "+ PlayerPrefs.GetInt("TotalCoins");
        }
    }


    public void IsMainMenuTrue()
    {
        isMainMenuTrue =  !isMainMenuTrue;
    }

}
