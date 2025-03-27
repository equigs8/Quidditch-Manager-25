using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTools : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       DontDestroyOnLoad(this); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneChanger(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
