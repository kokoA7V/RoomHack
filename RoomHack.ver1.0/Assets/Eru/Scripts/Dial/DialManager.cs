using UnityEngine;

public class DialManager : MonoBehaviour
{
    [HideInInspector]
    public bool dial1, dial2, dial3, dial4;

    void Start()
    {
        //�f�[�^������
        dial1 = false;
        dial2 = false;
        dial3 = false;
        dial4 = false;
    }

    void Update()
    {
        if(dial1 && dial2 && dial3 && dial4)
        {
            Debug.Log("���b�N����");
        }
    }
}
