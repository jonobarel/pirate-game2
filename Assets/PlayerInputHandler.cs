using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInputHandler : MonoBehaviour
{

    private Vector3 destination = Vector3.zero;
    
    private float MAX_VELOCITY = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Object Initiated");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Moving towards " + destination);
        
    }

    public void MouseClick(InputAction.CallbackContext context)
    {
        int action = (int)context.ReadValue<System.Single>();

        if (action == 1) {
            Vector3 clickLocation = Mouse.current.position.ReadValue();
            clickLocation.z = Camera.main.nearClipPlane;
            //Debug.Log("Registered a click at " + clickLocation);
            destination = Camera.main.ScreenToWorldPoint(clickLocation);
            Debug.Log ("registered world location at " + destination);
        }
        
    }
}
