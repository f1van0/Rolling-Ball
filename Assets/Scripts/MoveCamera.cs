using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool canBeMovable;
    private bool isStarted;
    public GameObject cam;


    private Vector2 deltaMousePosition;
    private Vector2 currentMousePosition;
    private Vector2 previousMousePosition;
    private Vector3 cameraRotation;

    public static CameraController instance;
    public float minRotationX = 10;
    public float maxRotationX = 80;

    public float sensitive = 5;

    public void OnDrag(PointerEventData eventData)
    {
        if (canBeMovable)
        {
            currentMousePosition = new Vector2(eventData.position.y, eventData.position.x);

            if (isStarted == true)
            {
                deltaMousePosition = Vector2.zero;
            }
            else
            {
                deltaMousePosition = currentMousePosition - previousMousePosition;
                deltaMousePosition.x = -deltaMousePosition.x;
            }
            

            cameraRotation = cam.transform.rotation.eulerAngles + (Vector3)deltaMousePosition / 20 * sensitive;
            cameraRotation.x = Mathf.Max(cameraRotation.x, minRotationX);
            cameraRotation.x = Mathf.Min(cameraRotation.x, maxRotationX);

            cam.transform.rotation = Quaternion.Euler(cameraRotation);
            previousMousePosition = currentMousePosition;
            isStarted = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        currentMousePosition = Vector3.zero;
        previousMousePosition = Vector3.zero;
        canBeMovable = true;
        isStarted = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canBeMovable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        canBeMovable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
