using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // La variable que guarda los puntos
    public static ScoreManager Instance;

    private int puntaje = 0;  // Almacenamos los puntos aquí

    // Aseguramos que solo haya una instancia de ScoreManager
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destruimos esta
        }
    }

    // Método para obtener los puntos actuales
    public int ObtenerPuntaje()
    {
        return puntaje;
    }

    // Método para agregar puntos
    public void SumarPuntos(int puntos)
    {
        puntaje += puntos;
    }

    // Método para reiniciar el puntaje (si es necesario)
    public void ReiniciarPuntaje()
    {
        puntaje = 0;
    }
}
