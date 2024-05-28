using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;

public class GameManager : MonoBehaviour
{
    //Объекты сцены
    private static GameObject arrowLeft;
    private static GameObject arrowRight;
    private static GameObject plane;
    private static GameObject go;
    private static GameObject light;
    private static GameObject ryan;
    private static GameObject transition;
    private static GameObject grass;
    private static GameObject hand1;
    private static GameObject hand2;
    private static GameObject leg1;
    private static GameObject leg2;
    private static GameObject bat;

    //Всякие флаги
    public static bool visableFlag = false;
    public static bool CameraMove = false;
    public static bool RyanMove = false;

    // Start is called before the first frame update
    void Start()
    {
        //Получаем объекты
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

        //Перемещаем объекты в нужные места
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

        // Делаем траву очень маленькой, чтоб она исчезла
        grass.transform.localScale = new Vector3(0, 0, 0);

        //Флаг говорит, что камере теперь можно идти за Гослингом
        CameraMove = true;
    }

    //функция ожидания
    IEnumerator ExampleCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        visableFlag = true;
    }


    void Update()
    {
        //Когда нажата Lets Go, то ждём немного
        if (StartButton.IsItLetsGo)
        {
            MusicScript.TimeToPlay = true;
            StartCoroutine(ExampleCoroutine(2.5f));
        }

        //Если была нажата Lets Go, то visableFlag == true
        //Тут мы расставляем все объекты на сцену, а старые скрываем
        if (visableFlag)
        {
            Renderer[] allRenderers = FindObjectsOfType<Renderer>();
            // Пройтись по всем рендерерам и отключить их
            foreach (Renderer renderer in allRenderers)
            {
                if (renderer.gameObject.name != "Square" && renderer.gameObject.name != "Grass" && renderer.gameObject.name != "bat")
                    renderer.enabled = false;
            }

            //Появляем траву
            var grass = GameObject.Find("Grass");
            grass.transform.localScale = new Vector3(0.9264008f, 0.9264008f, 0.9264008f);

            //Уменьшаем Гослинга и появляем его
            ryan.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            Renderer ryanRender = ryan.GetComponent<Renderer>();
            ryanRender.enabled = true;

            //Разрешаем Гослингу бежать за мышкой
            RyanMove = true;
            visableFlag = false;

            bat.transform.position = new Vector3(-6, 0, 0);
        }
    }
}