using UnityEngine;

public class Presentación : MonoBehaviour
{
    public void CargarEscena(int numero)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(numero);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
