using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rewind State is the subclass of the base state that fires when the leftmost button is selected
public class ArmControllerRewindState : ArmControllerBaseState
{
    //Enter state dictates what is designed to happen with the controller enters a new state
    public override void EnterState(ArmControllerStateManager ArmController){
        Animator animator = ArmController.GetComponent<Animator>();
        animator.Play("Rewind", 0, 0);
    }
    //Update State is used to change how the controller from one state to another, using a switch statement
    //It is also used to determine what the system is supposed to do while the current state is activated
    public override void UpdateState(ArmControllerStateManager ArmController){
        int selected = ArmController.Selected;
        if(selected != 1){
            Animator animator = ArmController.GetComponent<Animator>();
            animator.Play("Reverse Rewind", 0, 0);
            //This switch state is used to determine what state is now selevted based on the selected component on the main arm controller
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
    //currently, collisions are not implemented, however, there is some functionality for them in the future so they will remain as an empty function for now
    public override void OnCollisionEnter(ArmControllerStateManager ArmController, Collision collision){

    }
}
