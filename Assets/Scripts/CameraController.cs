using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 deltaMousePosition;
    private Vector2 currentMousePosition;
    private Vector2 previousMousePosition;
    private Vector3 cameraRotation;

    public static CameraController instance;
    public float minRotationX = 10;
    public float maxRotationX = 80;

    public float sensitive = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<CameraController>();
        }
        else
        {
            Debug.Log("CameraController object is already exist!");
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMousePosition = Vector3.zero;
        previousMousePosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        deltaMousePosition = new Vector2(Input.mousePosition.y, Input.mousePosition.x) - currentMousePosition;
        currentMousePosition = new Vector2(Input.mousePosition.y, Input.mousePosition.x);
        if ((deltaMousePosition.x < 0 && this.transform.rotation.x > -0.01f) || (deltaMousePosition.x > 0 && this.transform.rotation.x < 0.13f))
        {
            this.transform.rotation = Quaternion.Euler(currentMousePosition);
            Debug.Log("+");
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, currentMousePosition.y, 0);
            Debug.Log($"- {deltaMousePosition.x} -> {this.transform.rotation.x}");
        }
        */

        currentMousePosition = new Vector2(Input.mousePosition.y, Input.mousePosition.x);
        deltaMousePosition = currentMousePosition - previousMousePosition;
        Debug.Log($"Delta: {deltaMousePosition}  rotation x: {this.transform.rotation.eulerAngles.x}");
        
        cameraRotation = this.transform.rotation.eulerAngles + (Vector3)deltaMousePosition / 20 * sensitive;
        cameraRotation.x = Mathf.Max(cameraRotation.x, minRotationX);
        cameraRotation.x = Mathf.Min(cameraRotation.x, maxRotationX);

        this.transform.rotation = Quaternion.Euler(cameraRotation);
        previousMousePosition = currentMousePosition;
    }
}
