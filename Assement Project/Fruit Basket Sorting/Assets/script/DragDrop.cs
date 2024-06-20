
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour 
{
    private Vector3 originalPosition;

    public bool isLocked;

    void Awake()
    {
        isLocked = false;
         originalPosition = transform.position;
    }

    
    private void OnMouseDrag()
    {
        if (isLocked) return ;
        var a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        a.z = 0;
        transform.position = a;
    }
    private void OnMouseUp()
    {
        if (isLocked) return;
        transform.position = new Vector2(originalPosition.x, originalPosition.y);
    }


   public  void Correct(Vector3 position) 
    {
        transform.position = position;
    }


}
