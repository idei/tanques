using System.Collections;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    const int TAMAÑO_POOL_BALAS = 20;
    public GameObject bala;
    public GameObject fuego;
    public GameObject baseTanque;
    public GameObject inicioTanque;
    public KeyCode disparar;

    private Transform bandera = null;
    private Bala[] poolBalas = new Bala[TAMAÑO_POOL_BALAS];

    void Awake()
    {
        bala.SetActive(false);
        for (int i = 0; i < TAMAÑO_POOL_BALAS; i++)
        {
            poolBalas[i] = GameObject.Instantiate(bala).GetComponent<Bala>();
        }
    }

    private void Disparar()
    {
        Bala found = null;
        foreach (Bala bala in poolBalas)
        {
            if (!bala.gameObject.activeInHierarchy)
            {
                found = bala;
                break;
            }
        }
        if (found != null)
        {
            StartCoroutine(mostrarFuego());
            found.Disparar(fuego.transform);
        }
    }

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
        } else
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
            Disparar();
        }
    }
}
