using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 20f;                        //The camera paning speed
    public float screenBoundaryOffset = 5f;            //Distance away from screen borders where camera movement will start

    private bool moveEnabled = true;                    //Boolean variable used to enable/disable camera movement
	
	// Update is called once per frame
	void Update ()
    {

        //Call the function that moves the camera
        moveCamera();
	}

    void moveCamera()
    {
        //Pressing Spacebar sets this variable to false if already true and to true if already false
        if (Input.GetKeyDown(KeyCode.Space))
            if (moveEnabled)
                moveEnabled = false;
            else
                moveEnabled = true;

        //Which is then used to exit out of the code, meaning no camera movement will be done while this variable is false
        if (!moveEnabled)
            return;

        //Detect the mouse position and move the camera accordingly
        if (Input.mousePosition.y > Screen.height - screenBoundaryOffset)
        {
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime);
        }

        if (Input.mousePosition.y < screenBoundaryOffset)
        {
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime);
        }

        if (Input.mousePosition.x > Screen.width - screenBoundaryOffset)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }

        if (Input.mousePosition.x < screenBoundaryOffset)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }
    }
}
