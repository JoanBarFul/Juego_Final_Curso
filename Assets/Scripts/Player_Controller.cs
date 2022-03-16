using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    // Movimiento
    private float horizontalInput;
    private float verticalInput;
    private float rotateCameraXInput;
    private float rotateCameraYInput;

    // Fases HUD
    public GameObject hudAtack;
    public GameObject hudAtackSel;
    public GameObject hudPassive;
    public GameObject hudPassiveSel;
    

    // Velocidades
    public int speed = 5;
    private int speedRotate = 200;

    //Disparo
   
    private float atackTime = 1f;
   
    public bool canAtack = true;

    //Fase
    public bool atackFase = false;
    public bool passiveFase = false;
    

    //Animaciones
    public Animator playerAnimation;

    public GameObject katana;
    public GameObject colliderKatana;

    void Start()
    {
        // Fases HUD
        hudPassiveSel.SetActive(true);
        hudAtackSel.SetActive(false);
        katana.SetActive(false);
        playerAnimation = GetComponent<Animator>();
    }


    void Update()
    {
        // Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rotateCameraYInput = Input.GetAxis("Mouse Y");
        rotateCameraXInput = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.W))
        { playerAnimation.SetBool("isWalking", true); }
        else { playerAnimation.SetBool("isWalking", false); }

        

       
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * 2 * horizontalInput);
        // Movimento
        transform.Rotate(Vector3.up * Time.deltaTime * speedRotate * rotateCameraXInput);

        // Seleccionar fases
       

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(MeterKatana());
            DeselectFase();
           
            passiveFase = true;
            hudPassiveSel.SetActive(true);
            

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(SacarKatana());
            DeselectFase();
           
            atackFase = true;
            hudAtackSel.SetActive(true);
            
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        else { speed = 5; }

        

        if (Input.GetMouseButtonDown(0))
        {

            if (atackFase == true && canAtack == true)
            {

                StartCoroutine(Ataque());
                StartCoroutine(AtackTimer());

            }
        }
       
    }

    
    public IEnumerator Ataque()
    {
        playerAnimation.SetTrigger("trAtacar");
        yield return new WaitForSeconds(2f);
        Instantiate(colliderKatana, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1f, gameObject.transform.position.z), transform.rotation);


    }
    public void DeselectFase()
    {
        hudAtackSel.SetActive(false);
        hudPassiveSel.SetActive(false);
        
        atackFase = false;
        passiveFase = false;
       
    }

   

    public IEnumerator AtackTimer()
    {
        canAtack = false;
         yield return new WaitForSeconds(atackTime);
        canAtack = true;
    }

    public IEnumerator SacarKatana()
    {
        playerAnimation.SetTrigger("trSacar");
        yield return new WaitForSeconds(0.52f);
        katana.SetActive(true);

    }

    public IEnumerator MeterKatana()
    {
        playerAnimation.SetTrigger("trMeter");
        yield return new WaitForSeconds(1.35f);
        katana.SetActive(false);

    }

}

