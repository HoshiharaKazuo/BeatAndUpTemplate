using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventsController : MonoBehaviour
{
    public EnemyController controller;
    
    public void EnableMovement()
    {
        controller.EnableMovement();
    }

    public void DisableMovement()
    {
        controller.DiasbleMovement();
    }

    public void DestroyOnDeath()
    {
        controller.DestroyOnDeath();
    }
    public void PerformEnemyDeath()
    {
        controller.PerformEnemyDeath();
    }
}
