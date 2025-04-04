using Unity.VisualScripting;
using UnityEngine;

public class EnemySkillBasicShoot : EnemyBaseSkill
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int NumberOfBullet = 7;
    [SerializeField] private float TimeToShoot = 1.5f;
    private float Timer;

    protected override void Start()
    {
        Timer = 0f;
        base.Start();
        bullet = EnemyBulletPooling.instance.Bullet1Prefaps;
    }

    protected override void Update()
    {
        base.Update();
        if (NumberOfBullet > 0)
        {
            Timer += Time.deltaTime;
            if (Timer >= TimeToShoot)
            {
                Shoot();
                Timer = 0f;
                NumberOfBullet--;
            }

        }
    }

    private void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
