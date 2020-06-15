using System.Collections;
using UnityEngine;

public class JumperAttacker : Attacker
{

    protected override void CheckDefender(GameObject other)
    {
        var defender = other.GetComponent<Defender>();
        var canJump = other.CompareTag("Jumpable");
        if (defender)
        {
            if (canJump)
            {
                Jump();
            }
            else
            {
                StartAttacking(defender);
            }
        }
    }

    void Jump()
    {
        SetMovementSpeed(1);
        animator.SetTrigger("Jump");
    }

    void Run()
    {
        SetMovementSpeed(Speed);
    }    
    
    void Landing()
    {
        SetMovementSpeed(0);
    }
}



