using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    public float velocidad;
    public KeyCode teclaArriba;
    public KeyCode teclaDerecha;
    public KeyCode teclaAbajo;
    public KeyCode teclaIzquierda;
    private Rigidbody2D rígido;

    void Start()
    {
        rígido = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = 0;
        float v = 0;

        if (Input.GetKey(teclaDerecha))
        {
            h = 1;
        }
        if (Input.GetKey(teclaIzquierda))
        {
            h = -1;
        }
        if (Input.GetKey(teclaArriba))
        {
            v = 1;
        }
        if (Input.GetKey(teclaAbajo))
        {
            v = -1;
        }

        Vector2 tempVect = new Vector2(h, v);
        Vector2 pos = rígido.transform.position;

        if (tempVect != Vector2.zero)
        {
            rígido.rotation = Vector2.SignedAngle(Vector2.up, tempVect);
        }

        tempVect = tempVect * velocidad * Time.fixedDeltaTime;
        rígido.MovePosition(pos + tempVect);
    }
}
