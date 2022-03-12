using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RayCast : MonoBehaviour
{

    public float rayDistance = 2f;
    public GameObject pressE;
    public GameObject selRoca;
    private Color myColor;
    private string aldeaUnloaded = "s_Aldea";
    public GameObject casaPrueba; //prueba
    //color = new Color32(0x2a, 0x2B, 0x...


    void Start()
    {
        pressE.gameObject.SetActive(false);

        //Elegir color hexadecimal
        ColorUtility.TryParseHtmlString("#B6C8B3", out myColor);
    }

    void Update()
    {
        RaycastHit hit;

        // RayCast Aldea --> Montanya
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.collider.tag == "PuertaAldea")
            {
                pressE.gameObject.SetActive(true);

                Destroy(casaPrueba); //Prueba

                selRoca.GetComponent<MeshRenderer>().material.color = myColor;

                if (Input.GetKeyDown(KeyCode.E))
                { SceneManager.LoadScene("_Montanya"); } //LoadSceneMode.Additive
            }
        }
        else 
        { Deselect();}

        // RayCast Montanya --> Aldea
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.collider.tag == "PuertaMontanya")
            {
                pressE.gameObject.SetActive(true);

                selRoca.GetComponent<MeshRenderer>().material.color = myColor;

                if (Input.GetKeyDown(KeyCode.E))
                { SceneManager.LoadScene("_Aldea"); }
            }
        }
        else 
        { Deselect(); }
    }


   public void Deselect()
    {
        pressE.gameObject.SetActive(false);
        selRoca.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
