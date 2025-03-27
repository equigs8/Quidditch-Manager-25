using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour
{
    public GameObject gameManager;
    public SceneTools mySceneTools;
    public string nextScene;
    public UnityAction changeScene;
    Button myButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        mySceneTools = gameManager.GetComponent<SceneTools>();
        myButton = gameObject.GetComponent<Button>();
        AddOnClick();
    }

    public void AddOnClick()
    {
        myButton.onClick.AddListener(() => mySceneTools.SceneChanger(nextScene));
    }
}
