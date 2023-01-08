using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    private Camera cam;

    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		if (Input.GetButtonDown("Fire1"))
		{
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
		}

		if (Input.GetButton("Fire1"))
		{
            
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            gameObject.transform.position = new Vector3();

            //gameObject.transform.Rotate(new Vector3(1f, 0f, 0f), direction.y * 180);
            gameObject.transform.Rotate(new Vector3(0f, 1f, 0f), -direction.x * 180, Space.World);

            //float xAngle = Mathf.Clamp(gameObject.transform.rotation.eulerAngles.x, -45f, 45f);
            //Debug.Log(xAngle);

            //gameObject.transform.rotation = Quaternion.Euler(xAngle, gameObject.transform.rotation.eulerAngles.y, gameObject.transform.rotation.z);
            gameObject.transform.Translate(new Vector3(0f, 0f, 0f));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
		}
    }
}
