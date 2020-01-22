using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public TMPro.TMP_Text tiempos;
    public TMPro.TMP_Text textoAzul;
    public TMPro.TMP_Text textoRojo;

    void Start()
    {
        Globales.Reset();
        StartCoroutine(Controlador());
    }

    private IEnumerator Controlador()
    {
        for (int i = 0; i < 90; i++)
        {
            tiempos.text = i + "";
            textoAzul.text = Globales.puntajeAzul + "";
            textoRojo.text = Globales.puntajeRojo + "";
            Globales.tiempoRestante = 90 - i;
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene(2);
    }
}
