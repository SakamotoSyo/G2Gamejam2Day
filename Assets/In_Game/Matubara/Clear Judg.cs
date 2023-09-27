
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearJudg : MonoBehaviour
{
    [SerializeField]
    private string _clearSceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_clearSceneName);
        }
    }
}
