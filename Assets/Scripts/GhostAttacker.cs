using System.Collections;
using UnityEngine;

public class GhostAttacker : Attacker
{
    private const string unghostTrigger = "shouldUnGhost";
    private const string ghostTrigger = "shouldGhost";

    protected override void CheckDefender(GameObject other)
    {
        var defender = other.GetComponent<Defender>();
        if (defender)
        {
            Ghost();
        }
    }

    void Ghost()
    {
        animator.SetTrigger(ghostTrigger);
    }

    protected override void DidPassDefender(GameObject other)
    {
        //UnGhost(other);
    }


    protected virtual void UnGhost(GameObject other)
    {
        animator.SetTrigger(unghostTrigger);
        animator.ResetTrigger(ghostTrigger);
    }

}



