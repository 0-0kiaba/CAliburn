using UnityEngine;

//ArmControllerBaseState is an abstract class that serves as the basis for the entire state machine that controls the arm controller.
public abstract class ArmControllerBaseState
{
    //These classes are abstract, requiring all subclasses that inherit from it to include these methods
    public abstract void EnterState(ArmControllerStateManager ArmController);
    public abstract void UpdateState(ArmControllerStateManager ArmController);
    public abstract void OnCollisionEnter(ArmControllerStateManager ArmController, Collision collision);
}
