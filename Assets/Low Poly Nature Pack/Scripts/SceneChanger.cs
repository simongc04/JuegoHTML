using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Necesario para trabajar con UI y botones

public class ButtonSceneChanger : MonoBehaviour
{
    // Referencia al botón
    public Button sceneChangeButton;

    // El nombre de la escena a cargar
    public string sceneName;

    void Start()
    {
        // Asegurarse de que el botón esté asignado y establecer la acción
        if (sceneChangeButton != null)
        {
            sceneChangeButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("El botón no está asignado.");
        }
    }

    // Método para cambiar la escena
    void ChangeScene()
    {
        // Comprobamos si la escena está en la Build
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("La escena " + sceneName + " no está disponible en la Build.");
        }
    }
}
