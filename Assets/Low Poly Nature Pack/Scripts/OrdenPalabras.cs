using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrdenPalabras : MonoBehaviour
{
    public GameObject[] zonas; // Zonas donde se deben colocar las palabras
    public string[] palabrasCorrectas; // El orden correcto de las palabras
    public Button verificarButton; // El botón para verificar el orden
    public TextMeshProUGUI textoPuntaje; // Texto donde se mostrará el puntaje

    private string[] palabrasEnZonas; // Array para guardar las palabras que el jugador ha colocado
    private bool ordenCorrecto = false;
    private int puntaje = 0; // Variable para almacenar el puntaje

    void Start()
    {
        palabrasEnZonas = new string[zonas.Length]; // Inicializamos el array con el mismo tamaño que las zonas
        verificarButton.onClick.AddListener(VerificarOrden); // Al presionar el botón, se llama a la función de verificación
        ActualizarTextoPuntaje(); // Mostrar el puntaje inicial
    }

    void Update()
    {
        // Comprobamos las zonas y vemos qué palabras están colocadas en cada una
        for (int i = 0; i < zonas.Length; i++)
        {
            Collider[] colliders = Physics.OverlapBox(zonas[i].transform.position, zonas[i].transform.localScale / 2);
            palabrasEnZonas[i] = ""; // Reiniciamos para evitar datos antiguos

            foreach (Collider col in colliders)
            {
                if (col.gameObject.CompareTag("Palabra")) // Verificamos que el objeto tiene la etiqueta "Palabra"
                {
                    // Concatenamos palabras si hay más de una en la misma zona
                    if (!string.IsNullOrEmpty(palabrasEnZonas[i]))
                        palabrasEnZonas[i] += " ";

                    palabrasEnZonas[i] += col.gameObject.GetComponent<TextMeshPro>().text; // Guardamos el texto de la palabra
                }
            }
        }
    }

    void VerificarOrden()
    {
        ordenCorrecto = true;

        for (int i = 0; i < palabrasCorrectas.Length; i++)
        {
            if (palabrasEnZonas[i] != palabrasCorrectas[i]) // Comparamos las palabras en las zonas con las correctas
            {
                Debug.Log($"❌ Palabra incorrecta en la zona {i + 1}: Se esperaba '{palabrasCorrectas[i]}', pero se encontró '{palabrasEnZonas[i]}'");
                ordenCorrecto = false;
            }
            else
            {
                Debug.Log($"✅ Palabra correcta en la zona {i + 1}: '{palabrasCorrectas[i]}'");
            }
        }

        if (ordenCorrecto)
        {
            Debug.Log("🎯 ¡Orden Correcto!");  // Mensaje de éxito
            SumarPuntos(100); // Sumar 100 puntos si el orden es correcto
        }
        else
        {
            Debug.Log("❌ ¡Orden Incorrecto!");  // Mensaje de error
        }
    }

    // Función para sumar puntos
    void SumarPuntos(int puntos)
    {
        puntaje += puntos; // Sumamos los puntos
        ActualizarTextoPuntaje(); // Actualizamos el texto del puntaje
    }

    // Función para actualizar el texto que muestra el puntaje
    void ActualizarTextoPuntaje()
    {
        textoPuntaje.text = "Puntaje: " + puntaje.ToString(); // Actualizamos el texto con el puntaje actual
    }
}
