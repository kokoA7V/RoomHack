using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public bool gameOverFlg = false;
    public bool gameClearFlg = false;

    public GameObject gameOverUI, gameClearUI;
    public GameObject laser1, laser2, enemy;
    public GameObject blast;

    public MovePlayer mp;

    private float blastSpeed = 2f;

    private bool blastFlg = false;

    void Start()
    {
        //�f�[�^������
        gameOverFlg = false;
        gameClearFlg = false;
        blastFlg = false;
        gameClearUI.SetActive(false);
        gameOverUI.SetActive(false);
        laser2.SetActive(true);
        enemy.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Update()
    {
        //�Q�[���I�[�o�[
        if (gameOverFlg)
        {
            gameOverUI.SetActive(true);
        }

        //�Q�[���N���A
        if (gameClearFlg)
        {
            gameClearUI.SetActive(true);
        }

        //�I�u�W�F�N�g�N���b�N�擾
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == laser1)
            {
                Debug.Log("Clicked: " + laser1.name);
                // �����ɃN���b�N���̏������L�q����
            }

            if(hit.collider != null && hit.collider.gameObject == enemy)
            {
                Debug.Log("Clicked: " + enemy.name);
                // �����ɃN���b�N���̏������L�q����
            }
        }

        //���[�U�[�폜
        if (mp.laserFlg)
        {
            laser2.SetActive(false);
        }

        //�G�l�~�[�_�E��
        if (mp.enemyFlg)
        {
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
        }

        //�G�l�~�[�U��
        if(mp.corner2Flg && !mp.enemyFlg && !blastFlg)
        {
            blastFlg = true;
            Vector2 dir = mp.cornerPos2.transform.position - enemy.transform.position;
            dir.Normalize();

            GameObject bla = (GameObject)Instantiate(blast, enemy.transform.position, Quaternion.FromToRotation(Vector2.up, dir));
            Rigidbody2D brb = bla.GetComponent<Rigidbody2D>();
            brb.velocity = dir * blastSpeed;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
