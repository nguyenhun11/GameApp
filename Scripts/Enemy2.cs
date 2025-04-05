using NUnit.Framework.Constraints;
using UnityEngine;

public class Enemy2 : BaseEnemy
{
    protected override void Update()
    {
        base.Update();
        transform.rotation = rotationToPlayer();
    }
    private Quaternion rotationToPlayer()
    {
        Quaternion targetRotation;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if ((player.transform.position - transform.position).magnitude >= 1)
        {
            Vector3 direction = player.transform.position - this.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, 0, angle - 90);
        }
        else
        {
            float outAngle = transform.rotation.eulerAngles.z;
            outAngle++;
            targetRotation = Quaternion.Euler(0, 0, outAngle);
        }
        return Quaternion.RotateTowards(transform.rotation, targetRotation, 200 * Time.deltaTime);
    }

}
