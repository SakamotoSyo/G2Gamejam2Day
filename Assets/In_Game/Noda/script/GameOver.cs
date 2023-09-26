using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void OnClickStartButton(string _continue)
    {
        if(_continue == "Menu")
        {
            SceneManager.LoadScene("start");
        }
        else if(_continue == "Restart")
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
