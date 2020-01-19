public class Globales
{
    public static int puntajeAzul;
    public static int puntajeRojo;
    public static int tiempoRestante;
    public static string ganador;

    public static void Reset()
    {
        puntajeAzul = 0;
        puntajeRojo = 0;
        tiempoRestante = 90;
        ganador = "Empate";
    }
}
