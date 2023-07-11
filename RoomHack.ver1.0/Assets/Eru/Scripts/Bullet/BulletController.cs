using UnityEngine;

public class BulletController : MonoBehaviour,IUnitDamage
{
    public float maxHP { get; set; }
    public float nowHP { get; set; }
    public int dmgLayer { get; set; }

    public int pow;

    void Start()
    {
        maxHP = 1;
        nowHP = maxHP;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<IUnitDamage>(out var damage))
        {
            if(this.dmgLayer != damage.dmgLayer)
            {
                damage.HitDmg();
                this.HitDmg();
            }
        }
    }

    public void HitDmg()
    {
        nowHP--;
        if (nowHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
