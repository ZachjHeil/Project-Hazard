using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LoadoutScript : MonoBehaviour
{
    private VisualElement VisElTridentBG;
    private VisualElement VisElMultiThrowBG;
    private VisualElement visElStartRunBtn;
    Color enterMouse = new Color(189f/255f, 13f/255f, 13f/255f, 0.75f);
    Color exitMouse = new Color(84f/255f, 87f/255f, 90f/255f, 0.75f);
    
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        VisElTridentBG = root.Q<VisualElement>("TridentPrimary");
        VisElMultiThrowBG = root.Q<VisualElement>("TridentMulti");
        visElStartRunBtn = root.Q<VisualElement>("StartRun");

    }

    // Update is called once per frame
    void Update()
    {
        //Trident Primary
        VisElTridentBG.RegisterCallback<MouseEnterEvent>(ev => VisElTridentBG.style.backgroundColor = enterMouse);
        VisElTridentBG.RegisterCallback<MouseLeaveEvent>(ev => VisElTridentBG.style.backgroundColor = exitMouse);
        //Trident Multi Throw
        VisElMultiThrowBG.RegisterCallback<MouseEnterEvent>(ev => VisElMultiThrowBG.style.backgroundColor = enterMouse);
        VisElMultiThrowBG.RegisterCallback<MouseLeaveEvent>(ev => VisElMultiThrowBG.style.backgroundColor = exitMouse);
    
        //Start Run button
        visElStartRunBtn.RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("Stage_1"));
    
    }
}
