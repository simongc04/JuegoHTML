using UnityEngine;

public class DragWord : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private bool isDragging = false;

    private void OnMouseDown()
    {
        // Desactivar el raycast para los demás objetos.
        isDragging = true;
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        // Cuando se suelta el ratón, dejamos de arrastrar el objeto.
        isDragging = false;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;  // Mantener la posición en Z
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
