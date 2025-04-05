using UnityEngine;
using System.Collections;

public class EnemySkillMultiShoot : EnemyBaseSkill
{
    [SerializeField] private int NumberOfBullets;
    [SerializeField] private float SpreadAngle = 10;
    [SerializeField] private float TimerBetweenShoot = 0.2f;
    private float Clock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void ActiveSkill()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        int bulletLeft = NumberOfBullets;
        float angle = AngleToPlayer();
        angle -= SpreadAngle * NumberOfBullets / 3;
        while (bulletLeft > 0)
        {
            GameObject bullet1 = PoolingEnemyBullet1.instance.GetBullet();
            bullet1.transform.position = transform.position;
            bullet1.transform.rotation = Quaternion.Euler(0, 0, angle);
            
            bulletLeft--;
            angle += SpreadAngle;
            yield return new WaitForSeconds(TimerBetweenShoot);
        }
    }

    private float AngleToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 directionToPlayer = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x)*Mathf.Rad2Deg - 90;
        return angle;
    }
}
