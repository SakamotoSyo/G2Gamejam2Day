using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultRestartbutton : MonoBehaviour
{
    public void OnClickMainButton(string Clear)
    {
        SceneManager.LoadScene("Main");
    }

}
