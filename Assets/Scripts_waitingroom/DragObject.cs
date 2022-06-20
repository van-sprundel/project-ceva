using UnityEngine;

public class DragObject : MonoBehaviour
{
    public delegate void DragEndedDelegate(DragObject dragObject);

    public bool isSnapped;
    public bool isDragged;

    public DragEndedDelegate dragEndedCallback;
    private Vector3 mOffset;
    private float mZCoord;

    private void OnMouseDown()
    {
        isDragged = true;
        var position = gameObject.transform.position;
        mZCoord = Camera.main.WorldToScreenPoint(
            position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = position - GetMouseAsWorldPoint();
    }

    private void OnMouseDrag()
    {
        // if (isDragged)
        if (isDragged && !isSnapped) transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnMouseUp()
    {
        isDragged = false;
        dragEndedCallback(this);
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        var mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}