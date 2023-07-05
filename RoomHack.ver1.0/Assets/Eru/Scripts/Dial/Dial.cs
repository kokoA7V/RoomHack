using UnityEngine;

public class Dial : MonoBehaviour
{
    private const float rotation1 = 24.5f;
    private const float rotation2 = 25.5f;

    private float rotationZ;

    private bool isDragging = false;

    private float dragSpeed = 5f;

    public DialManager dialManager;

    [SerializeField]
    private int myDial;

    void Start()
    {
        // オブジェクトの初期回転をランダムに設定する
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        transform.rotation = randomRotation;
    }

    void Update()
    {
        if (dialManager.missFlg) return;

        rotationZ = transform.rotation.eulerAngles.z;

        //ダイヤル判定
        if (rotationZ >= rotation1 && rotationZ <= rotation2)
        {
            if (myDial == 1)
            {
                dialManager.dial1 = true;
            }
            else if (myDial == 2)
            {
                dialManager.dial2 = true;
            }
            else if (myDial == 3)
            {
                dialManager.dial3 = true;
            }
            else
            {
                dialManager.dial4 = true;
            }
        }
        else
        {
            //回転
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            if (isDragging)
            {
                float rotationAmount = Input.GetAxis("Mouse X") * dragSpeed;
                Vector3 currentRotation = transform.rotation.eulerAngles;
                currentRotation.z += rotationAmount;
                transform.rotation = Quaternion.Euler(currentRotation);
            }
        }
    }
}
