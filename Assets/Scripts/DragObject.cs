using UnityEngine;

public class DragObject : MonoBehaviour
{
    public delegate void DragEndedDelegate(DragObject dragObject);

    public DragEndedDelegate dragEndedCallback;
    
    private bool isDragged = false;
    private Vector3 mOffset;
    private float mZCoord;

    private void OnMouseUp()
    {
        isDragged = false;
        dragEndedCallback(this);
    }

    private void OnMouseDown()
    {
        isDragged = true;
        var position = gameObject.transform.position;
        mZCoord = Camera.main.WorldToScreenPoint(
            position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }
}