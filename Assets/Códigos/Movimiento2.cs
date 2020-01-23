using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    // Fuerza del motor para mover la masa del objeto
    public float fuerza;
    // Posición de la oruga izquierda
    public Transform oruga_izquierda;
    // Posición de la oruga derecha
    public Transform oruga_derecha;
    // Teclas de avance y giro configurables
    public KeyCode teclaArriba;
    public KeyCode teclaDerecha;
    public KeyCode teclaAbajo;
    public KeyCode teclaIzquierda;
    // Contendrá una referencia al componente de cuerpo rígido
    private Rigidbody2D rígido;
    // Contendrá una referencia al componente de fuerza constante
    private ConstantForce2D motor;

    void Start()
    {
        // Inicializo las referencias a los componentes agregados al GameObject
        motor = GetComponent<ConstantForce2D>();
        rígido = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // inicialmente, no hay movimiento de ningún tipo
        float rotación = 0f;
        float direcciónMotor = 0f;
        // el centro de masa (y de rotación) está en el centro del sprite
        rígido.centerOfMass = Vector2.zero;

        bool esTeclaDerecha = Input.GetKey(teclaDerecha);
        bool esTeclaIzquierda = Input.GetKey(teclaIzquierda);
        bool esTeclaArriba = Input.GetKey(teclaArriba);
        bool esTeclaAbajo = Input.GetKey(teclaAbajo);

        if (esTeclaDerecha)
        {
            // cuando presiona la tecla para girar a derecha, el centro de masa
            // se traslada al lugar donde está la oruga derecha
            rígido.centerOfMass = oruga_derecha.localPosition;
            // inicio la velocidad de rotación equivalente a la fuerza negativa del motor
            rotación = -fuerza;
        }
        if (esTeclaIzquierda)
        {
            // cuando presiona la tecla para girar a izquierda, el centro de masa
            // se traslada al lugar donde está la oruga izquierda
            rígido.centerOfMass = oruga_izquierda.localPosition;
            // inicio la velocidad de rotación equivalente a la fuerza positiva del motor
            rotación = fuerza;
        }
        if (esTeclaArriba)
        {
            // cuando presiona la tecla hacia arriba (avanzar), la dirección del motor es
            // equivalente a la fuerza positiva configurada.
            direcciónMotor = fuerza;
        }
        if (esTeclaAbajo)
        {
            // cuando presiona la tecla hacia abajo (retroceder), la dirección del motor es
            // equivalente a la fuerza negativa configurada.
            direcciónMotor = -fuerza;
        }
        if (!esTeclaIzquierda && !esTeclaDerecha)
        {
            // si no presiona ninguna tecla de dirección, frena el movimiento rotacional
            rígido.angularVelocity = 0f;
        }
        if (!esTeclaArriba && !esTeclaAbajo)
        {
            // si no presiona ninguna tecla de movimiento, frena el movimiento
            rígido.velocity = Vector2.zero;
        }
        motor.force = transform.rotation * Vector2.up * direcciónMotor;
        motor.torque = rotación;
    }
}
