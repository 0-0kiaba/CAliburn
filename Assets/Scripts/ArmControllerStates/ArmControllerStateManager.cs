using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControllerStateManager : MonoBehaviour
{
    ArmControllerBaseState CurrentState;
    public ArmControllerRewindState RewindState = new ArmControllerRewindState();
    public ArmControllerPauseState PauseState = new ArmControllerPauseState();
    public ArmControllerPlayState PlayState = new ArmControllerPlayState();
    public ArmControllerFastForwardState FastForwardState = new ArmControllerFastForwardState();
    public int Selected;
    // Start is called before the first frame update
    void Start()
    {
        //Starting State for the State Machine
        CurrentState = PauseState;   
        Selected = 2;
        CurrentState.EnterState(this);
    }

    void OnCollisionEnter(Collision collision){
        CurrentState.OnCollisionEnter(this, collision);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(ArmControllerBaseState state){
        CurrentState = state;
        CurrentState.EnterState(this);
    }
    public void setSelected(int selected){
        Selected = selected;
    }
}
