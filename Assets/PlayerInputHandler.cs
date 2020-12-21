using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInputHandler : MonoBehaviour
{
   
    public GameObject ship;
    private Vector3 destination = Vector3.zero;
    
    private float MAX_VELOCITY = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Object Initiated");
    }

    // Update is called once per frame
    void Update()
    {
        ship.transform.position = Vector3.MoveTowards(ship.transform.position, destination, MAX_VELOCITY*Time.deltaTime);
        return;
      
    }

    public void MouseClick(InputAction.CallbackContext context)
    {
        int action = (int)context.ReadValue<System.Single>();
        Debug.Log("MouseClick event detected");

        if (action == 1) {
            Vector2 clickLocation = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(clickLocation);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Clicked on " + hit.collider.name);
                destination = hit.point;
                destination.y = ship.transform.position.y;
            }
             else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
        
    }
}
