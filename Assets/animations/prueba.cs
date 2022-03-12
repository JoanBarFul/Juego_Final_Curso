using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class prueba : MonoBehaviour
{
    // Movimiento
    private float horizontalInput;
    private float verticalInput;
    private float rotateCameraXInput;
    private float rotateCameraYInput;

    // Fases HUD
    

    // Velocidades
    public int speed = 5;
    private int speedRotate = 500;

    //Disparo
    private float shotTime = 30f;
    private float atackTime = 1f;
    public bool canShot = true;
    public bool canAtack = true;

    //Fase
    public bool atackFase = false;
    public bool passiveFase = false;
    public bool shotFase = false;
     


    void Start()
    {
        // Fases HUD
        Vector3 SpawnPos = new Vector3(0, 0, 0);
    }


    void Update()
    {
        // Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rotateCameraYInput = Input.GetAxis("Mouse Y");
        rotateCameraXInput = Input.GetAxis("Mouse X");

        // Movimento
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * speedRotate * rotateCameraXInput);

        // Seleccionar fases
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
           
            shotFase = true;
           
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           
            passiveFase = true;
          
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            atackFase = true;
          
        }

       if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        } 
       else { speed = 5; }

        if (Input.GetMouseButtonDown(0))
        {
            if (shotFase == true && canShot == true)
            {
                Debug.Log ("PUM"); //Disparar
                StartCoroutine(ShotTimer());
            }

            if (atackFase == true && canAtack == true)
            {
                Debug.Log ("SLASH"); //Atacar
                StartCoroutine(AtackTimer());
            }
        }
    }

    public void SelectFase(KeyCode numero, GameObject hud, bool fase)
    {
        if(Input.GetKeyDown(numero))
        {
            DeselectFase();
            hud.SetActive(true);
            fase = true;
        }
    }

    public void DeselectFase()
    {
        
        atackFase = false;
        passiveFase = false;
        shotFase = false;
    }

    public IEnumerator ShotTimer()
    {
        canShot = false;
        DeselectFase();
    
        yield return new WaitForSeconds(shotTime);
        canShot = true;
    }

    public IEnumerator AtackTimer()
    {
        canAtack = false;
        yield return new WaitForSeconds(atackTime);
        canAtack = true;
    }
}

