using Unity.VisualScripting;
using UnityEngine;

public class EnemySkillBasicShoot : EnemyBaseSkill
{

    protected override void ActiveSkill()
    {
        GameObject bullet1 = PoolingEnemyBullet1.instance.GetBullet();
        bullet1.transform.position = transform.position;
        bullet1.transform.rotation = transform.rotation;
    }


}
