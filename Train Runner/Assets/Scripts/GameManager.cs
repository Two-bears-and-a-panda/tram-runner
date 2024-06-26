using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static UnityEngine.ParticleSystem;

public class GameManager : MonoBehaviour
{
    // пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
    private static GameObject arrowLeft;
    private static GameObject arrowRight;
    private static GameObject plane;
    private static GameObject go;
    private static GameObject light;
    public static GameObject ryan;
    private static GameObject transition;
    private static GameObject grass;
    private static GameObject hand1;
    private static GameObject hand2;
    private static GameObject leg1;
    private static GameObject leg2;
    private static GameObject bat;
    private static GameObject cake;
    private static GameObject capsule;
    private static GameObject conductor;
    private static GameObject train;
    private static GameObject train2;

    public static float TopBorder = 2.6f;
    public static float BottomBorder = -2.6f;


    // пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
    public static bool visableFlag = false;
    public static bool CameraMove = false;
    public static bool RyanMove = false;
    public static bool TakeSomething = false;

    // Start is called before the first frame update
    void Start()
    {
        // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ
        arrowLeft = GameObject.Find("ArrowLeft");
        arrowRight = GameObject.Find("ArrowRight");
        plane = GameObject.Find("back");
        grass = GameObject.Find("Grass");
        go = GameObject.Find("LetsGo");
        light = GameObject.Find("Light");
        ryan = GameObject.Find("Ryan");
        transition = GameObject.Find("Square");
        hand1 = GameObject.Find("Hand1");
        hand2 = GameObject.Find("Hand2");
        leg1 = GameObject.Find("Leg1");
        leg2 = GameObject.Find("Leg2");
        bat = GameObject.Find("bat");
        cake = GameObject.Find("Cake");
        capsule = GameObject.Find("Capsule");
        conductor = GameObject.Find("Conductor");
        train = GameObject.Find("Train");
        train2 = GameObject.Find("Train2");


        // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
        arrowLeft.transform.position = new Vector3(-4.96f, 0.02f, 0);
        arrowRight.transform.position = new Vector3(5.15f, 0.08f, 0);
        light.transform.position = new Vector3(-0.2200007f, -2.38f, 0);
        transition.transform.position = new Vector3(0, 0, 0);
        grass.transform.position = new Vector3(0, 0, 0);
        ryan.transform.position = new Vector3(0, 0, 0);
        plane.transform.position = new Vector3(0, 0, 0);
        go.transform.position = new Vector3(5.79f, 3.69f, 0);
        hand1.transform.position = new Vector3(0, 0, 0);
        hand2.transform.position = new Vector3(0, 0, 0);
        leg1.transform.position = new Vector3(0, 0, 0);
        leg2.transform.position = new Vector3(0, 0, 0);
        capsule.transform.position = new Vector3(-7.6f, 4.3f, 0);

        // пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ
        grass.transform.localScale = new Vector3(0, 0, 0);

        // пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
        CameraMove = true;

        // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ Conductor пїЅ пїЅпїЅпїЅпїЅпїЅпїЅ
        conductor.GetComponent<Renderer>().enabled = false;
    }

    // пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
    IEnumerator ExampleCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        visableFlag = true;
    }

    IEnumerator ShowConductorAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ Conductor пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅ Ryan
        Renderer conductorRender = conductor.GetComponent<Renderer>();
        conductorRender.enabled = true;
        conductor.GetComponent<MoveToGosling>().target = ryan;

    }

    void Update()
    {
        TakeSomething = batScript.TakeIt || CakeScript.TakeIt;
        Debug.Log(TakeSomething);

        // пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ Lets Go, пїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ
        if (StartButton.IsItLetsGo)
        {
            MusicScript.TimeToPlay = true;
            StartCoroutine(ExampleCoroutine(2.5f));
            Camera.FindObjectOfType<VideoPlayer>().enabled = false;
        }

        // пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ Lets Go, пїЅпїЅ visableFlag == true
        // пїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ, пїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ
        if (visableFlag)
        {
            Renderer[] allRenderers = FindObjectsOfType<Renderer>();
            // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ
            foreach (Renderer renderer in allRenderers)
            {
                if (renderer.gameObject.name is not ("Square" or "Grass" or "bat" or "Cake" or "Capsule" or "Seat" or "Granny"))
                    renderer.enabled = false;
            }
            train.GetComponent<Renderer>().enabled = true;
            train2.GetComponent<Renderer>().enabled = true;

            // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
            var grass = GameObject.Find("Grass");
            grass.transform.localScale = new Vector3(0.9264008f, 0.9264008f, 0.9264008f);
        }

        if (Train.arrived && visableFlag)
        {
            // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ
            ryan.transform.localScale = new Vector3(.3f, .3f, 0);
            Renderer ryanRender = ryan.GetComponent<Renderer>();
            ryanRender.enabled = true;

            

            // пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ
            RyanMove = true;

            bat.transform.position = new Vector3(-6, 0, 0);
            cake.transform.position = new Vector3(6, 0, 0);
            visableFlag = false;

            // пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ
            grass.GetComponent<Renderer>().enabled = false;

            StartCoroutine(ShowConductorAfterDelay(4f));
        }
    }
}
