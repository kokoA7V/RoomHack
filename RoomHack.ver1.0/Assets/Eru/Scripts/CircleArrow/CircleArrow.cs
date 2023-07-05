using UnityEngine;

public class CircleArrow : MonoBehaviour
{ 
    public CircleArrowManager cam;

    private float rotationSpeed = 5.0f;
    private float rotationZ;

    private const float right1 = 252.0f;
    private const float right2 = 286.0f;

    private const float left1 = 76.0f;
    private const float left2 = 110.0f;

    void Update()
    {
        if (cam.rotationStopFlg) return;

        //��]
        transform.Rotate(Vector3.forward * rotationSpeed);

        //�t��]����
        if (cam.rotationFlg)
        {
            cam.rotationFlg = false;
            rotationSpeed *= -1;
        }

        //�������C���ɓ����Ă��邩�̔���
        rotationZ = transform.rotation.eulerAngles.z;

        if (rotationZ <= right2 && rotationZ >= right1)
        {
            cam.inFlg = true;
        }
        else if(rotationZ <= left2 && rotationZ >= left1)
        {
            cam.inFlg = true;
        }
        else
        {
            cam.inFlg = false;
        }
    }
}
