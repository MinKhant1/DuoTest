using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternMaker : MonoBehaviour
{


    public Button btnMain;
    public Button btnProc;
    public Sprite spForward;
    public Sprite spLeft;
    public Sprite spRight;
    public Sprite spLight;
    public Sprite spP1;
    public Sprite spBlank;
    public Sprite spTarget;
    public Sprite spOn;




    private string type; //either main or proc
    private List<int> mainSteps; // keeps track of the steps the user entered for main
    private List<int> procSteps; // keeps track of the steps the user entered for proc
    private int maxMain = 12; // maximum steps allowed in main
    private int maxProc = 8; // maximum steps allowed in proc
    private Dictionary<int, Sprite> iconDict;

    // Use this for initialization
    void Start()
    {

        mainSteps = new List<int>();
        procSteps = new List<int>();


        // initializing the icon dictionary
        iconDict = new Dictionary<int, Sprite>() {
            { 0, spForward },
            { 1, spLeft },
            { 2, spRight },
            { 3, spLight },
            { 4, spP1 }
        };
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mainSteps.Count; i++)
        {
            Image img = (Image)GameObject.Find(string.Format("img_m{0:00}", i + 1)).GetComponent<Image>();
            img.sprite = iconDict[mainSteps[i]];
        }
        for (int i = 0; i < procSteps.Count; i++)
        {
            Image img = (Image)GameObject.Find(string.Format("img_p{0:00}", i + 1)).GetComponent<Image>();
            img.sprite = iconDict[procSteps[i]];
        }
    }

    public void AddToStepList(int index)
    {


        if (mainSteps.Count < maxMain)
            mainSteps.Add(index);



    }


}

