using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSixtyFollower : MonoBehaviour
{
    [SerializeField]
    GameObject imageSet0;

    Vector3 moveVector = new Vector3();

    float moveAmount = 7680;

    void Start()
	{
        
    }

    void Update()
    {
        Follower();
    }

    void Follower()
	{
        if(imageSet0.transform.position.x > 0)
		{
            moveVector = new Vector3(imageSet0.transform.position.x - moveAmount, transform.position.y, transform.position.z);
        }
        else
		{
            moveVector = new Vector3(imageSet0.transform.position.x + moveAmount, transform.position.y, transform.position.z);
        }
        transform.position = moveVector;
    }
}
