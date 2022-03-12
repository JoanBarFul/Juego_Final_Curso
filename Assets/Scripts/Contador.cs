using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI contadortext;
    public int contador;


    void Start()
    {
        contador = 15;
        contadortext.text = $"Muñecos restantes {contador}";
    }


    void Update()
    {
        contadortext.text = $"Muñecos restantes {contador}";

        if (contador <= 0)
        {
            SceneManager.LoadScene("_Montanya");
        }
    }
}
