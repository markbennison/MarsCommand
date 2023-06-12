using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSixthMover : MonoBehaviour
{
    Vector3 moveVector = new Vector3();
    float outerBounds = 7680;

    [SerializeField]
    float panSpeed = 1000f;
    [SerializeField]
    float mouseSensitivity = 10000f;
    float panAmount;

    void Start()
    {
		
	}

    void Update()
    {
		PanCamera();
		PanCameraByMouse();
		outerBoundsReset();
    }

    void PanCamera()
	{
        panAmount = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;
        transform.Translate(panAmount, 0, 0);
    }

    void PanCameraByMouse()
    {
        if (Input.GetButton("Fire1"))
        {
            panAmount = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
			transform.Translate(panAmount, 0, 0);
        }
    }

    void outerBoundsReset()
	{
		if (transform.localPosition.x <= -outerBounds || transform.localPosition.x >= outerBounds)
        {
            moveVector = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = moveVector;
        }
    }
}
