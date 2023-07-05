using UnityEngine;

public class CircleArrowManager : MonoBehaviour
{
    public bool inFlg = false;

    public bool rotationFlg = false;
    public bool rotationStopFlg = false;

    public int clearCount = 5;

    void Start()
    {
        Debug.Log(clearCount);
    }

    void Update()
    {
        if (clearCount <= 0)
        {
            rotationStopFlg = true;
            Debug.Log("�N���A");
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (inFlg)
                {
                    //�������C���ɓ����Ă���Ƃ��̏���
                    rotationFlg = true;
                    clearCount--;
                    Debug.Log(clearCount);
                }
                else
                {
                    //�������C���ɓ����Ă��Ȃ��Ƃ��̏���
                    Debug.Log("�~�X");
                }
            }
        }
    }
}
