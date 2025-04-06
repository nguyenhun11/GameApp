using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBaseSkill : MonoBehaviour
{
    protected GameObject bullet;
    public int NumberOfSkill = 7;
    public float TimeToActive = 1.5f;
    private float Timer;
    protected virtual void Start()
    {
        ActiveSkill();
        Timer = 0f;
        bullet = PoolingEnemyBullet1.instance.Bullet1Prefaps;
    }

    protected virtual void Update()
    {
        if (NumberOfSkill > 0)
        {
            Timer += Time.deltaTime;
            if (Timer >= TimeToActive)
            {
                ActiveSkill();
                Timer = 0f;
                NumberOfSkill--;
            }

        }
    }


    protected virtual void ActiveSkill()
    {
    
    }
    
}
