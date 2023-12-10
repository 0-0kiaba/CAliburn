using UnityEngine;

public abstract class ArmControllerBaseState
{
    public abstract void EnterState(ArmControllerStateManager ArmController);
    public abstract void UpdateState(ArmControllerStateManager ArmController);
    public abstract void OnCollisionEnter(ArmControllerStateManager ArmController, Collision collision);
}
