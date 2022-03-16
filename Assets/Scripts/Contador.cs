using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI contadortext;
    public int contador;
    public GameObject winText;


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
            StartCoroutine(WinCanvas());
            
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            contador = 0;
        }
    }
    public IEnumerator WinCanvas()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("_Montanya");
    }
}
