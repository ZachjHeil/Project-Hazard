using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private Label StartRunBtn, ExitGameBtn, CredScreenBtn;
    


    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        StartRunBtn = root.Q<Label>("NewRunButton");
        ExitGameBtn = root.Q<Label>("ExitGameButton");
        CredScreenBtn = root.Q<Label>("CreditsButton");
    }

    // Update is called once per frame
    void Update()
    {
        StartRunBtn.RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("LoadoutSelectV1"));
        ExitGameBtn.RegisterCallback<ClickEvent>(ev => Application.Quit());

    }

    
}
