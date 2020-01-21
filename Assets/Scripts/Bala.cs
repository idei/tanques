using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private ConstantForce2D fuerza;
    public float potenciaBala = 100f;
    public GameObject explosion;
    public AudioSource ruidoExplosion;
    public Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        fuerza = GetComponent<ConstantForce2D>();
    }

    public void Disparar(Transform origen)
    {
        transform.position = origen.position;
        transform.rotation = origen.rotation;
        GetComponent<ConstantForce2D>().force = origen.rotation * Vector2.up * potenciaBala;
        gameObject.SetActive(true);
        explosion.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "base" || other.tag == "bala")
        {
            return;
        }
        if (other.tag == "irrompible")
        {
            StartCoroutine(_explotar());
        }

        Tanque tank = other.GetComponent<Tanque>();

        if (tank != null)
        {
            StartCoroutine(_explotar());
            tank.Explotar();
        }
    }

    IEnumerator _explotar()
    {
        GameObject.Destroy(gameObject, 1f);
        GetComponent<ConstantForce2D>().force = Vector2.zero;
        rigid.velocity = Vector2.zero;
        ruidoExplosion.Play();
        explosion.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
}
