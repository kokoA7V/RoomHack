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
            Debug.Log("クリア");
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (inFlg)
                {
                    //白いラインに入っているときの処理
                    rotationFlg = true;
                    clearCount--;
                    Debug.Log(clearCount);
                }
                else
                {
                    //白いラインに入っていないときの処理
                    Debug.Log("ミス");
                }
            }
        }
    }
}
