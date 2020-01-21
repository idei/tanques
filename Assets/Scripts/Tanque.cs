using System.Collections;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    public GameObject modeloBala;
    public GameObject fuego;
    public GameObject baseTanque;
    public GameObject inicioTanque;
    public KeyCode disparar;
    private Transform bandera = null;

    private IEnumerator mostrarFuego()
    {
        fuego.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        fuego.SetActive(false);
    }

    public void Explotar()
    {
        transform.position = inicioTanque.transform.position;
        transform.rotation = Quaternion.identity;
        if (tag == "Azul")
        {
            Globales.puntajeRojo++;
        }
        else
        {
            Globales.puntajeAzul++;
        }
        if (bandera != null)
        {
            bandera.parent = null;
            bandera.position = Vector2.zero;
            bandera.rotation = Quaternion.identity;
            bandera.gameObject.GetComponent<Collider2D>().enabled = true;
            bandera = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bandera")
        {
            other.transform.parent = transform;
            other.transform.localPosition = Vector2.zero;
            other.GetComponent<Collider2D>().enabled = false;
            bandera = other.transform;
        }
        else if (other.gameObject == baseTanque)
        {
            if (bandera != null)
            {
                Globales.ganador = "Gana el tanque " + tag;
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(disparar))
        {
            GameObject copiaBala = GameObject.Instantiate(modeloBala);
            Bala bala = copiaBala.GetComponent<Bala>();
            bala.Disparar(fuego.transform);
            StartCoroutine(mostrarFuego());
        }
    }
}
