using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using Cinemachine;
public class PlayerInputSystem : MonoBehaviour
{

    public static event Action OnInteractionPressed;

    InputAction movement;
    [SerializeField]Transform cameraTransform;

    StarterAssetsInput starterAssetInput;

    PlayerMovement playerMovement;

    ThirdPersonController thirdPersonController;

   [SerializeField]
    private float maxRotationSpeed = 1f;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }



    private void OnEnable()
    {

        starterAssetInput = new StarterAssetsInput();
        starterAssetInput.Player.Enable();


        starterAssetInput.Player.Click.performed += Walk;
        starterAssetInput.Player.Click.Enable();

        starterAssetInput.Player.DoubleClick.performed += Run;
        starterAssetInput.Player.DoubleClick.Enable();

        starterAssetInput.Player.Interact.performed += InteractSystem;
        starterAssetInput.Player.Interact.Enable();

        starterAssetInput.Player.CameraRotate.performed += RotateCamera;
        starterAssetInput.Player.CameraRotate.Enable();




    }

   
    private void OnDisable()
    {
        starterAssetInput.Player.Click.Disable();
        starterAssetInput.Player.DoubleClick.Disable();
        starterAssetInput.Player.Interact.Disable();
        starterAssetInput.Player.CameraRotate.Disable();
    }



    private void Walk(InputAction.CallbackContext context)
    {

        Vector2 mousePosition2D = Mouse.current.position.ReadValue();

       

        Vector3 mousePosition3D = new Vector3(mousePosition2D.x,mousePosition2D.y,0f);

       // thirdPersonController.Move(mousePosition3D);
        playerMovement.Movement(mousePosition3D,true);

        
    }



    private void Run(InputAction.CallbackContext context)
    {
        Vector2 mousePosition2D = Mouse.current.position.ReadValue();

        Vector3 mousePosition3D = new Vector3(mousePosition2D.x, mousePosition2D.y, 0f);

        // thirdPersonController.Move(mousePosition3D);
        playerMovement.Movement(mousePosition3D, false);
    }



    private void InteractSystem(InputAction.CallbackContext context)
    {


        OnInteractionPressed?.Invoke();

        Debug.Log("Pressed E");
    }











    private void RotateCamera(InputAction.CallbackContext context)
    {
        if (!Mouse.current.rightButton.isPressed)
            return;

        float value = context.ReadValue<Vector2>().x;
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x, value * maxRotationSpeed + cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
        Debug.Log("Yes");
    }






}
