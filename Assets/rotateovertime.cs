using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateovertime : MonoBehaviour
{
    public Quaternion quaternion;
    public float lerpTime = 1;
    public float RotateAmount = 1;

    public bool rotate;
    public bool rotateConstantly;
    // Start is called before the first frame update
    void Start()
    {
        quaternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, Time.deltaTime * lerpTime);
         if (rotateConstantly)
            transform.Rotate(Vector3.forward * RotateAmount);

                }
    public void SnapRotation()
    {
        transform.rotation = quaternion;
    }
}
