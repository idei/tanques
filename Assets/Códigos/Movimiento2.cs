using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    public float fuerza;
    public Transform oruga_izquierda;
    public Transform oruga_derecha;
    public KeyCode teclaArriba;
    public KeyCode teclaDerecha;
    public KeyCode teclaAbajo;
    public KeyCode teclaIzquierda;
    private Rigidbody2D rígido;
    private ConstantForce2D motor;

    void Start()
    {
        motor = GetComponent<ConstantForce2D>();
        rígido = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float rotación = 0f;
        float direcciónMotor = 0f;
        rígido.centerOfMass = Vector2.zero;

        if (Input.GetKey(teclaDerecha))
        {
            rígido.centerOfMass = oruga_derecha.localPosition;
            rotación = -fuerza;
            rígido.velocity = Vector2.zero;
        }
        if (Input.GetKey(teclaIzquierda))
        {
            rígido.centerOfMass = oruga_izquierda.localPosition;
            rotación = fuerza;
            rígido.velocity = Vector2.zero;
        }
        if (Input.GetKey(teclaArriba))
        {
            direcciónMotor = 1f;
            rígido.angularVelocity = 0f;
        }
        if (Input.GetKey(teclaAbajo))
        {
            direcciónMotor = -1f;
            rígido.angularVelocity = 0f;
        }
        motor.force = transform.rotation * Vector2.up * direcciónMotor * fuerza;
        motor.torque = rotación;
    }
}
