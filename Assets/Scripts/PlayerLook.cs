using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform cameraTrans;
    public float lookSensitivity = 2f;
    public float lookSmoothing = 0.5f;
    public float rotationLimit = 80f;
    public bool smoothing = true;

    private float xRotation;
    private float yRotation;
    private float currentXRotation;
    private float currentYRotation;
    private float xRotationV;
    private float yRotationV;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddRotation(float lookX, float lookY)
    {
        xRotation -= lookX * lookSensitivity;
        yRotation += lookY * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, -rotationLimit, rotationLimit);

        currentXRotation = smoothing && lookSmoothing > 0.0f ? 
            Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothing) : 
            xRotation;
        currentYRotation = smoothing && lookSmoothing > 0.0f ?
            Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothing) :
            yRotation;

        if(currentXRotation != 0.0f)
        {
            cameraTrans.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
        }

        if(currentYRotation != 0.0f)
        {
            rb.rotation = Quaternion.Euler(0f, currentYRotation, 0f);
        }
    }
}
