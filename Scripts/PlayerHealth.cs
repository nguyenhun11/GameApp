using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 5;
    public int Health;
    public float timeOfTempDie = 2f;
    private bool isTempDeathActive = false;
    private float Timer;
    public bool IsFainted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
        Timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isTempDeathActive)
        {
            Timer += Time.deltaTime;
            if (Timer > timeOfTempDie)
            {
                isTempDeathActive = false;
                Timer = 0f;
                Revive();
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //ModifyHealth(collision.gameObject.GetComponent<GeneralEnemy>().damage);
            TempDeath();
        }
    }

    public void ModifyHealth(int a)
    {
        Health = Mathf.Min(MaxHealth, Health + a);
    }
    public void TempDeath()
    {
        Timer = 0f;
        Fainted();
        isTempDeathActive = true;
    }
    private void Fainted()
    {
        IsFainted = true;
        GetComponent<Collider2D>().enabled = false;


    }
    private void Revive()
    {
        IsFainted = false;
        GetComponent<Collider2D>().enabled = true;
        //transform.Find("eye").gameObject.SetActive(true);
    }

}
