using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThreeSixthMover : MonoBehaviour
{
    Vector3 moveVector = new Vector3();
    float outerBounds = 7680;

    [SerializeField]
    float panSpeed = 1000f;
    [SerializeField]
    float mouseSensitivity = 10000f;
    float panAmount;
    bool panLeft, panRight, panLeftEnter, panRightEnter = false;

	public void PanLeft(bool value)
	{
		panLeft = value;
	}

	public void PanLeftEnter(bool value)
    {
		panLeftEnter = value;
	}

	public void PanRight(bool value)
	{
		panRight = value;
	}

	public void PanRightEnter(bool value)
    {
		panRightEnter = value;
    }

    void Start()
    {

	}

    void Update()
    {
		PanCamera();
		//PanCameraByMouse();
		outerBoundsReset();
    }

    void PanCamera()
	{
        Debug.Log("Status " + panLeft + " " + panLeftEnter + " " + panRight + " " + panRightEnter);

        if (panLeft && panLeftEnter && !panRight && !panRightEnter)
        {
			panAmount = panSpeed * Time.deltaTime;
		}
        else if (panRight && panRightEnter && !panLeft && !panLeftEnter) 
        {
			panAmount = -panSpeed * Time.deltaTime;
        }
        else
        {
            panAmount = 0;
        }

        //panAmount = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;
        if (panAmount > -0.1 && panAmount < 0.1)
        {
            panAmount = 0;
        }

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
