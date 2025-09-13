using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class InterfaceExecutive : MonoBehaviour
{
    public Scene gameScene;

    private VisualElement root;


    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("Play").clicked += StartGame;
    }


    void StartGame()
    {
        SceneManager.LoadScene("Home");
    }
}
