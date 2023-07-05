using UnityEngine;

public class DialManager : MonoBehaviour
{
    [HideInInspector]
    public bool dial1, dial2, dial3, dial4;

    void Start()
    {
        //データ初期化
        dial1 = false;
        dial2 = false;
        dial3 = false;
        dial4 = false;
    }

    void Update()
    {
        if(dial1 && dial2 && dial3 && dial4)
        {
            Debug.Log("ロック解除");
        }
    }
}
