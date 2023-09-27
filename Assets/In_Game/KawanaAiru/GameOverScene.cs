using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "peoples")
        {
            SceneManager.LoadScene("result");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
