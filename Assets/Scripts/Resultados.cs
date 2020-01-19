using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resultados : MonoBehaviour
{
    public TMPro.TMP_Text resultado;
    public TMPro.TMP_Text puntosRojo;
    public TMPro.TMP_Text puntosAzul;
    public TMPro.TMP_Text tiempoRestante;

    void Start()
    {
        resultado.text = Globales.ganador;
        puntosAzul.text = "Puntos Tanque Azul: " + Globales.puntajeAzul;
        puntosRojo.text = "Puntos Tanque Rojo: " + Globales.puntajeRojo;
        tiempoRestante.text = "Tiempo restante: " + Globales.tiempoRestante;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void CargarEscena(int numero)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(numero);
    }
}
