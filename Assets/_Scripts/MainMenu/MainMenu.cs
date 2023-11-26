using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Nombre de la escena a la que se cambiará
    public string nivelAIniciar = "NombreDeLaEscena";

    // Método para iniciar el juego (llamado por un botón)
    public void IniciarJuego()
    {
        SceneManager.LoadScene(nivelAIniciar);
    }

    // Método para salir del juego (llamado por un botón)
    public void SalirDelJuego()
    {
        // Este código funcionará en la versión compilada, pero no en el editor de Unity
        // Ya que Unity no permite salir directamente desde el editor.
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
