using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The state behavior is a monobehavior script designed to serve as a hub for all of the states that this state machine is responsible for
public class ArmControllerStateManager : MonoBehaviour
{
    //The currentstate dictates what state is currently being enacted0
    ArmControllerBaseState CurrentState;
    //the different states that are used within the arm controller
    public ArmControllerRewindState RewindState = new ArmControllerRewindState();
    public ArmControllerPauseState PauseState = new ArmControllerPauseState();
    public ArmControllerPlayState PlayState = new ArmControllerPlayState();
    public ArmControllerFastForwardState FastForwardState = new ArmControllerFastForwardState();

    //integer that tracks the current state for animations
    public int Selected;

    // Start is called before the first frame update
    //This start simply defines the current state as the pause state, and enters the pause states enterState function
    void Start()
    {
        //Starting State for the State Machine
        CurrentState = PauseState;   
        Selected = 2;
        CurrentState.EnterState(this);
    }

    //OnCollisionEnter calls the current state's function of the same name
    void OnCollisionEnter(Collision collision){
        CurrentState.OnCollisionEnter(this, collision);
    }

    // Update is called once per frame
    //Update plays the current state's update function
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    //SwitchState is designed to implement a proper way in which one state can seemlessly transfer into another,
    //changing the current state, and then plays the enterState function of that new state
    public void SwitchState(ArmControllerBaseState state){
        CurrentState = state;
        CurrentState.EnterState(this);
    }
    //function designed to change what integer selected is
    public void setSelected(int selected){
        Selected = selected;
    }
}
