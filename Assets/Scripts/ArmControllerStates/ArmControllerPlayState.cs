using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControllerPlayState : ArmControllerBaseState
{
    public override void EnterState(ArmControllerStateManager ArmController){
        Animator animator = ArmController.GetComponent<Animator>();
        animator.Play("Play", 0, 0);

    }
    public override void UpdateState(ArmControllerStateManager ArmController){
        int selected = ArmController.Selected;
        if(selected != 3){
            Animator animator = ArmController.GetComponent<Animator>();
            animator.Play("Reverse Play", 0, 0);
            switch(selected){
                case 1:
                ArmController.SwitchState(ArmController.RewindState);
                break;
                case 2:
                ArmController.SwitchState(ArmController.PauseState);
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
