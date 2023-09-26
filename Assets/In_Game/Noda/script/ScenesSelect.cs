using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSelect : MonoBehaviour
{
    public void OnClickStartButton(string Level)
    {
        if (Level == "hard")
        {
            SceneManager.LoadScene("Hard");
        }
        else if (Level == "normal")
        {

            SceneManager.LoadScene("Normal");
        }
        else
        {
            SceneManager.LoadScene("Easy");
        }
    }
}
