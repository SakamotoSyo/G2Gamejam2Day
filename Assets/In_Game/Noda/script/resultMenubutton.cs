using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultMenubutton : MonoBehaviour
{
    public void OnClickStartButton(string Clear)
    {
        SceneManager.LoadScene("start");
    }
}
