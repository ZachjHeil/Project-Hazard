using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuScript : MonoBehaviour
{
    HUDScript HudScript;

    public bool GamePaused = false;
    private VisualElement PauseMenuUI;
    private Label labPauseTitle;
    private Label labResume;
    private Label labControls;
    private Label labOptions;
    private Label labCredits;
    private Label labQuit;
    
    
    // Start is called before the first frame update
    void Start()
    {
        HudScript = FindObjectOfType<HUDScript>();
        PauseMenuUI = GetComponent<UIDocument>().rootVisualElement;
        labPauseTitle = PauseMenuUI.Q<Label>("StageTitleLabel");
        labResume = PauseMenuUI.Q<Label>("ResumeLabel");
        labControls = PauseMenuUI.Q<Label>("ControlsLabel");
        labOptions = PauseMenuUI.Q<Label>("OptionsLabel");
        labCredits = PauseMenuUI.Q<Label>("CreditsLabel");
        labQuit = PauseMenuUI.Q<Label>("QuitLabel");
        PauseMenuUI.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if(GamePaused)
        {
            labResume.RegisterCallback<ClickEvent>(ev => Resume());
        }
    }

    void Resume ()
    {
        PauseMenuUI.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
        GamePaused = false;
    }
    
    void Pause ()
    {
        PauseMenuUI.style.display = DisplayStyle.Flex;
        //labPauseTitle.text = HudScript.thisSceneName;
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
