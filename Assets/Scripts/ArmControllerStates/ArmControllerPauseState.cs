using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControllerPauseState : ArmControllerBaseState
{
    public override void EnterState(ArmControllerStateManager ArmController){
        Animator animator = ArmController.GetComponent<Animator>();
        animator.Play("Pause", 0, 0);

    }
    public override void UpdateState(ArmControllerStateManager ArmController){
        int selected = ArmController.Selected;
        if(selected != 2){
            Animator animator = ArmController.GetComponent<Animator>();
            animator.Play("Reverse Pause", 0, 0);
            switch(selected){
                case 1:
                ArmController.SwitchState(ArmController.RewindState);
                break;
                case 3:
                ArmController.SwitchState(ArmController.PlayState);
                break;
                case 4:
                ArmController.SwitchState(ArmController.FastForwardState);
                break;
            }
        }
    }
    public override void OnCollisionEnter(ArmControllerStateManager ArmController, Collision collision){
        
    }
}
