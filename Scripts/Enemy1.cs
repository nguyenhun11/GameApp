using NUnit.Framework.Constraints;
using UnityEngine;

public class Enemy1 : BaseEnemy
{
    protected override Quaternion firstRotation(Vector3 spawnPosition)
    {
        float Height = Camera.main.orthographicSize;
        float Width = Camera.main.aspect * Height;

        if (spawnPosition.y < -Height)
            return Quaternion.identity;
        else if (spawnPosition.y > Height)
            return Quaternion.Euler(0, 0, 180);
        else if (spawnPosition.x > Width)
            return Quaternion.Euler(0, 0, 90);
        else if (spawnPosition.x < -Width)
            return Quaternion.Euler(0, 0, -90);

        return base.firstRotation(spawnPosition);
    }
    


}
