using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSemiTransparent : MonoBehaviour
{
    private static List<GameObject> TransparentObjects=new List<GameObject>();
    private Transform myCamera;
    private CharacterController PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController = transform.GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 Target = PlayerController.transform.position;
        Target.y += 2;
        Ray ray = new Ray(myCamera.position, Target-myCamera.position);
        GameObject HitGameObject = null;
        if (Physics.Raycast(ray, out RaycastHit hit,1024))
        {
            //Переделать условие на проверку расстояния до игрока и точки попадания
            if (hit.transform.gameObject != PlayerController.gameObject)/*Сюда попадаю только если сделать коллайдер стенки в два раза больше*/
            {
                HitGameObject = hit.transform.gameObject;
                Renderer HitObjectRenderer = HitGameObject.GetComponent<Renderer>();
                if(!TransparentObjects.Contains(hit.transform.gameObject ))
                {
                    TransparentObjects.Add(hit.transform.gameObject);
                }
                Color CurrentColor = HitObjectRenderer.material.color;
                CurrentColor.a = 0.5f;
                HitObjectRenderer.material.color = CurrentColor;
            }
        }
        foreach (GameObject TransparentObject in TransparentObjects)
        {
            if (TransparentObject != HitGameObject)
            {
                Renderer ThisObjectRenderer =TransparentObject.GetComponent<Renderer>();
                Color CurrentColor = ThisObjectRenderer.material.color;
                CurrentColor.a = 1.0f;
               ThisObjectRenderer.material.color = CurrentColor;
            }
        }   
    }
 
}
