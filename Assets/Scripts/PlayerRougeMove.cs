using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRougeMove : MonoBehaviour
{

    public float moveTime = 0.1f;
    public Rigidbody rb;
    private float inverseMoveTime;




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
        rb = GetComponent<Rigidbody>();
        inverseMoveTime = 1f / moveTime;



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

        // StartCoroutine(SmoothMovement());


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



    //inverseMoveTime* Time.deltaTime

    public void move()
    {
        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(0, 0, 1);

        Vector3 newPostion = Vector3.MoveTowards(rb.position, end, 0.3f);
        rb.MovePosition(newPostion);
    }


    protected IEnumerator SmoothMovement()
    {
        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * 1;
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while (sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rb.position, end, inverseMoveTime * Time.deltaTime);




            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb.MovePosition(newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
    }

    void rotate(bool dir)
    {
        if (dir)
            transform.Rotate(new Vector3(0, -90, 0));
        if (!dir)
            transform.Rotate(new Vector3(0, 90, 0));
    }

    IEnumerator ExecuteSteps()
    {
        foreach (int action in mainSteps)
        {
            if (action == 0)
            { // move forward
                StartCoroutine("SmoothMovement");
                yield return new WaitForSeconds(1f);
            }
            else if (action == 1)
            { // turn left
                rotate(true);
                yield return new WaitForSeconds(1f);
            }
            else if (action == 2)
            { // turn right
                rotate(false);
                yield return new WaitForSeconds(1f);
            }
            /*
           else if (action == 3)
           { // toggle light
               toggleLight();
               yield return new WaitForSeconds(1f);
           }
          else if (action == 4)
           { // run P1
               foreach (int act in procSteps)
               {
                   if (act == 0)
                   { // move forward
                       MoveForward();
                   }
                   else if (act == 1)
                   { // turn left
                       Turn(true);
                   }
                   else if (act == 2)
                   { // turn right
                       Turn(false);
                   }
                   else if (act == 3)
                   { // toggle light
                       toggleLight();
                   }
                   */
            yield return new WaitForSeconds(0.5f); // pause for 1 second bewtween each step
        }
    }



    public void Run()
    {
        StartCoroutine(ExecuteSteps());
    }

    public void AddToStepList(int index)
    {



        if (mainSteps.Count < maxMain)
            mainSteps.Add(index);

    }
}
        // TODO: check success
       


