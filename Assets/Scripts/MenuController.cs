using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

   // public InputField sizeField;
    public InputField countField;
    public InputField scoreField;

    //public int fieldSize;
    public int enemyCount;
    public int scoreToWin;

    public void PlayGame()
    {
        //fieldSize =  Int32.Parse(sizeField.text);
        enemyCount = Int32.Parse(countField.text);
        scoreToWin = Int32.Parse(scoreField.text);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    public void QuiteGame ()
    {
        Application.Quit();
    }
    void OnDisable()
    {
        //PlayerPrefs.SetInt("size",  fieldSize );
        PlayerPrefs.SetInt("count", enemyCount);
        PlayerPrefs.SetInt("score", scoreToWin);
        
    }
}
