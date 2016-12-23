using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerLook playerLook;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();
    }

    private void Update()
    {
        playerMovement.SetMoveDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerLook.AddRotation(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
    }
}
