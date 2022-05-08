using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
	public float turnSpeed = 15;
	private Camera mainCamera;
	private Transform parent;
	

    private void Start()
    {
	    mainCamera = Camera.main;
	    Cursor.visible = false;
	    Cursor.lockState = CursorLockMode.Locked;
	    
    }
    void FixedUpdate()
    {
	    float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
	    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0),
		    turnSpeed * Time.fixedDeltaTime);
		
    }
	
	
	
}
