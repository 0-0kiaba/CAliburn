using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToIndex : MonoBehaviour
{
    //poke interactor variable that gets will be changed to index finger
    public Transform PokeAttachPoint; 
    //the poke interactor
    private XRPokeInteractor XrPointInteractor;
    // Start is called before the first frame update
    //assigns the point interactor, and then assigns its attach point to the end of the index finger
    void Start()
    {
        XrPointInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
        setPoke();
    }

    //makes the Attach point for the point interactor to the end of the hand's index finger, if it has not already been assigned to something else
    void setPoke()
    {
        XrPointInteractor.attachTransform = PokeAttachPoint;
    }
}
