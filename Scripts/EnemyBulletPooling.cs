using UnityEngine;

public class EnemyBulletPooling : MonoBehaviour
{
    #region singleton
    public static EnemyBulletPooling instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion 
    public GameObject Bullet1Prefaps;
    protected void Start()
    {
        
    }

    protected void Update()
    {
        
    }
}
