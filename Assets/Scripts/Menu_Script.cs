using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    //Botones
    public Button buttonStart;
    public Button buttonControls;
    public Button buttonExit;

    //HUD
    public GameObject startGameObject;
    public GameObject controlsGameObject;
    public GameObject exitGameObject;
    public GameObject unoGameObject;
    public GameObject dosGameObject;
  
    public GameObject atacarGameObject;
    public GameObject caminarGameObject;
 
    public GameObject protegerObject;
    public GameObject correrObject;
    public GameObject escapeGameObject;



    void Start()
    {
        Deselect();

        startGameObject.SetActive(true);
        controlsGameObject.SetActive(true);
        exitGameObject.SetActive(true);

        buttonStart.onClick.AddListener(TaskOnClick_Start);
        buttonControls.onClick.AddListener(TaskOnClick_Controls);
        buttonExit.onClick.AddListener(TaskOnClick_Exit);
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Deselect();
            unoGameObject.SetActive(true);
            dosGameObject.SetActive(true);
            
            atacarGameObject.SetActive(true);
            caminarGameObject.SetActive(true);
            protegerObject.SetActive(true);
            correrObject.SetActive(true);
            escapeGameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Deselect();
            unoGameObject.SetActive(true);
            dosGameObject.SetActive(true);
            
            caminarGameObject.SetActive(true);
            escapeGameObject.SetActive(true);
        }

       

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Deselect();
            startGameObject.SetActive(true);
            controlsGameObject.SetActive(true);
            exitGameObject.SetActive(true);
        }
    }

    void TaskOnClick_Start()
    {
        SceneManager.LoadScene("_Montanya");
    }

    void TaskOnClick_Controls()
    {
        Deselect();
        unoGameObject.SetActive(true);
        dosGameObject.SetActive(true);
       
        escapeGameObject.SetActive(true);
    }

    void TaskOnClick_Exit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Deselect()
    {
        startGameObject.SetActive(false);
        controlsGameObject.SetActive(false);
        exitGameObject.SetActive(false);
        unoGameObject.SetActive(false);
        dosGameObject.SetActive(false);
       
        atacarGameObject.SetActive(false);
        caminarGameObject.SetActive(false);
       
        protegerObject.SetActive(false);
        correrObject.SetActive(false);
        escapeGameObject.SetActive(false);
    }
}
