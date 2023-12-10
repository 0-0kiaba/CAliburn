using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControllerRewindState : ArmControllerBaseState
{
    public override void EnterState(ArmControllerStateManager ArmController){
        Animator animator = ArmController.GetComponent<Animator>();
        animator.Play("Rewind", 0, 0);
    }
    public override void UpdateState(ArmControllerStateManager ArmController){
        int selected = ArmController.Selected;
        if(selected != 1){
            Animator animator = ArmController.GetComponent<Animator>();
            animator.Play("Reverse Rewind", 0, 0);
            switch(selected){
                case 2:
                ArmController.SwitchState(ArmController.PauseState);
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
