using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject modeloBala;
    public GameObject fuego;
    public KeyCode teclaDisparar;

    void Update()
    {
        if (Input.GetKeyDown(teclaDisparar))
        {
            GameObject copiaBala =  GameObject.Instantiate(modeloBala);
            Bala bala = copiaBala.GetComponent<Bala>();
            bala.Disparar(fuego.transform);
        }
    }
}
