using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Misiones : MonoBehaviour
{
    public GameObject misiones;
    
    // Start is called before the first frame update
    void Start()
    {
        misiones.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
                { misiones.gameObject.SetActive(true); }
        else    { misiones.gameObject.SetActive(false); }
        
    }
}
