using UnityEngine;
using UnityEngine;

public class ControlPantallaBienvenida : MonoBehaviour
{
    public GameObject pantallaBienvenida;  // El Panel de fondo (pantalla de bienvenida)
    public GameObject textoBienvenida;     // Texto de bienvenida
    public GameObject botonIniciar;        // Botón de iniciar juego

    void Start()
    {
        // Inicialmente todo está visible
        pantallaBienvenida.SetActive(true);
        textoBienvenida.SetActive(true);
        botonIniciar.SetActive(true);
    }

    // Este método se llama cuando presionas el botón "Iniciar Juego"
    public void IniciarJuego()
    {
        pantallaBienvenida.SetActive(false); // Oculta el panel
        textoBienvenida.SetActive(false);    // Oculta el texto
        botonIniciar.SetActive(false);       // Oculta el botón
    }
}
