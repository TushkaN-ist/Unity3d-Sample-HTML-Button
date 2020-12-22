using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Vector3 euler;
	private void Awake()
	{
        euler = transform.localEulerAngles;
    }
	// Update is called once per frame
	void Update()
    {
        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0))
        {
            euler[0] = Mathf.Clamp(euler[0]- Input.GetAxis("Mouse Y"), -35, 35);
            euler[1] += Input.GetAxis("Mouse X");
            transform.localRotation = Quaternion.Euler(euler);
        }
    }
}
