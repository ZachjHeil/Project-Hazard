using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class HUDScript : MonoBehaviour
{
    
    public Label labHP;
    public VisualElement visElHPBar;
    private Label labExp;
    private Label labLevel;
    private Label labTaskA;
    private Label labTaskB;
    private Label labTaskC;
    private Label labStageTitle;
    private VisualElement visElExpProg;
    /*private VisualElement visElExp1;
    private VisualElement visElExp2;
    private VisualElement visElExp3;
    private VisualElement visElExp4;
    private VisualElement visElExp5;*/
    
    BaseStats baseStatsScript;
    ExpSystem expScript;
    Elevator elevatorScript;
    stage2 stage2Script;
    
    private float tempoExp;
    private float expPercentage;

    Color expBarOn = new Color(67f/255f, 195f/255f, 234f/255f, 1f);
    Color expBarOff = new Color(132f/255f, 149f/255f, 154f/255f, 1f);

    private float hpPercentage;

    public string thisSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        baseStatsScript = FindObjectOfType<BaseStats>();

        elevatorScript = FindObjectOfType<Elevator>();
        

        expScript = FindObjectOfType<ExpSystem>();
        expScript.level = 1;

        expPercentage = expScript.experience/expScript.expNeeded;

        //ExpUIUpdate();
        Scene thisScene = gameObject.scene;
        
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        labHP = rootVisualElement.Q<Label>("HpLabel");
        visElHPBar = rootVisualElement.Q<VisualElement>("HpBar");

        labExp = rootVisualElement.Q<Label>("ExpLabel");
        labLevel = rootVisualElement.Q<Label>("LvLabel");
        visElExpProg = rootVisualElement.Q<VisualElement>("ExpProgress");

        labTaskA = rootVisualElement.Q<Label>("TaskALabel");
        labTaskB = rootVisualElement.Q<Label>("TaskBLabel");
        labTaskC = rootVisualElement.Q<Label>("TaskCLabel");

        labStageTitle = rootVisualElement.Q<Label>("StageLabel");

        /*visElExp1 = rootVisualElement.Q<VisualElement>("Exp1");
        visElExp2 = rootVisualElement.Q<VisualElement>("Exp2");
        visElExp3 = rootVisualElement.Q<VisualElement>("Exp3");
        visElExp4 = rootVisualElement.Q<VisualElement>("Exp4");
        visElExp5 = rootVisualElement.Q<VisualElement>("Exp5");*/
        
        
        /*visElExp1.style.backgroundColor = expBarOff;
        visElExp2.style.backgroundColor = expBarOff;
        visElExp3.style.backgroundColor = expBarOff;
        visElExp4.style.backgroundColor = expBarOff;
        visElExp5.style.backgroundColor = expBarOff;*/

        if(thisScene.name == "Stage_1")
        {
            thisSceneName = "Stage 1";
            labStageTitle.text = "Stage 1";
            labTaskA.text = "Find a fusion core";
            labTaskB.text = "Find a detonator";
            labTaskC.text = "Use the elevator";
        }
        if(thisScene.name == "Stage_2")
        {
            thisSceneName = "Stage 2";
            stage2Script = FindObjectOfType<stage2>();
            labStageTitle.text = "Stage 2";
            labTaskA.text = "Charge pylons to power the teleporter:";
            labTaskB.text = $"{stage2Script.chargedPads}/3 pylons charged";
            labTaskC.text = "'Not charging...'";
        }
    }

    // Update is called once per frame
    void Update()
    {
        labHP.text = $"{baseStatsScript.CurrentHealth} / {baseStatsScript.MaxHealth}";
        hpPercentage = baseStatsScript.CurrentHealth/baseStatsScript.MaxHealth;    
        visElHPBar.style.width = new StyleLength(Length.Percent(hpPercentage*100)); 

        labExp.text = $"Exp. {expScript.experience}";
        labLevel.text = $"Lvl. {expScript.level}";

        if(tempoExp != expScript.experience) //if the experience gained or lost exp
        {
            ExpUIUpdate();
        }
        
        if(thisSceneName == "Stage 1")
        {
            
            if(elevatorScript.explosive)
            {
                labTaskA.style.color = Color.green;
            }
            if(elevatorScript.detonator)
            {
                labTaskB.style.color = Color.green;
            }

        }
        if(thisSceneName == "Stage 2")
        {
            labTaskB.text = $"{stage2Script.chargedPads}/3 pylons charged";

            if(stage2Script.chargedPads == 3)
            {
                labTaskA.text = "Elevator charged";
                labTaskA.style.color = Color.green;
                labTaskB.style.color = Color.green;
                labTaskC.text = "Use the elevator";
            }
            if(stage2Script.playercharging)
            {
                labTaskC.text = "'Charging...'";
            }
            if(stage2Script.playercharging == false)
            {
                labTaskC.text = "'Not charging...'";
            }
        }


        
    }
    void ExpUIUpdate()
    {
        tempoExp = expScript.experience;
        expPercentage = expScript.experience/expScript.expNeeded;
        visElExpProg.style.width = new StyleLength(Length.Percent(expPercentage*100));

        /*if(expPercentage < 0.2 || expPercentage > 1.0)                //OLD EXP BAR UPDATE SYSTEM
        {
            visElExp1.style.backgroundColor = expBarOff;
            visElExp2.style.backgroundColor = expBarOff;
            visElExp3.style.backgroundColor = expBarOff;
            visElExp4.style.backgroundColor = expBarOff;
            visElExp5.style.backgroundColor = expBarOff;
        }
        if(expPercentage >= 0.2)
        {
            visElExp1.style.backgroundColor = expBarOn;
            visElExp2.style.backgroundColor = expBarOff;
            visElExp3.style.backgroundColor = expBarOff;
            visElExp4.style.backgroundColor = expBarOff;
            visElExp5.style.backgroundColor = expBarOff;
        }
        if(expPercentage >= 0.4)
        {
            visElExp1.style.backgroundColor = expBarOn;
            visElExp2.style.backgroundColor = expBarOn;
            visElExp3.style.backgroundColor = expBarOff;
            visElExp4.style.backgroundColor = expBarOff;
            visElExp5.style.backgroundColor = expBarOff;
        }
        if(expPercentage >= 0.6)
        {
            visElExp1.style.backgroundColor = expBarOn;
            visElExp2.style.backgroundColor = expBarOn;
            visElExp3.style.backgroundColor = expBarOn;
            visElExp4.style.backgroundColor = expBarOff;
            visElExp5.style.backgroundColor = expBarOff;
        }
        if(expPercentage >= 0.8)
        {
            visElExp1.style.backgroundColor = expBarOn;
            visElExp2.style.backgroundColor = expBarOn;
            visElExp3.style.backgroundColor = expBarOn;
            visElExp4.style.backgroundColor = expBarOn;
            visElExp5.style.backgroundColor = expBarOff;
        }*/
    }
}
