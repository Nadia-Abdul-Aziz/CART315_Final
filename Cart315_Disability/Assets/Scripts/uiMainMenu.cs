using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class uiMainMenu : MonoBehaviour
{
    private Button startButton;
    private Button optionsButton;
    private Button quitButton;

    private int GameSceneIndex = 0;

    void OnEnable()
    {

    
        
    var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        optionsButton = root.Q<Button>("OptionsButton");
        quitButton = root.Q<Button>("QuitButton");

        startButton.clicked += OnStartClicked;
        optionsButton.clicked += OnOptionsClicked;
        quitButton.clicked += OnQuitClicked;

        Debug.Log("Events registered");
    }

    void OnDisable()
    {
        startButton.clicked -= OnStartClicked;
        optionsButton.clicked -= OnOptionsClicked;
        quitButton.clicked -= OnQuitClicked;
    }

    void OnStartClicked()
    {
        SceneManager.LoadScene(GameSceneIndex);

        GetComponent<UIDocument>().rootVisualElement.style.display = DisplayStyle.None;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        //FindObjectOfType<PlayerInputHandler>().enabled = true;
        
        Debug.Log("START CLICKED");

    }

    void OnOptionsClicked()
    {
        Debug.Log("Open options menu");
    }

    void OnQuitClicked()
    {
        Application.Quit();
        Debug.Log("Quit pressed");
    }
}

