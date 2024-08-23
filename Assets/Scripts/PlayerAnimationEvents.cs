using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    
    public void EnableMovement()
    {
        playerController.EnableMovement();
    }

    public void DisableMovement() {

        playerController.DisableMovement();
    }
}
