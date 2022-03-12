using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class detect_collisions : MonoBehaviour
{
    public Contador contadorScript;

    void Start()
    {
        contadorScript = FindObjectOfType<Contador>();
    }

    void OnCollisionEnter(Collision otherCollider)
    {

        if (otherCollider.gameObject.CompareTag("paja"))
        {
            Destroy(otherCollider.gameObject);
            contadorScript.contador = contadorScript.contador -1;
        }
    }
}
