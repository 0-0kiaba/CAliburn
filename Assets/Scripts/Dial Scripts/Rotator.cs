using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rotator : MonoBehaviour
{
    //In order to understand what any of this does, use https://www.youtube.com/watch?v=vIrgCMNsE3s as reference
    //Any modifications will be documented as they pop up if they occur
    [SerializeField] Transform linkedDial;
    [SerializeField] private int snapRotationAmount;
    [SerializeField] private float angleTolerance;
    [SerializeField] private GameObject RightHandModel;
    //removed leftHandModel since there is no way to really interact with dials using left hand
    [SerializeField] bool shouldUseDummyHands;
    private XRBaseInteractor interactor;
    private float startAngle;
    private bool requiresStartAngle = true;
    private bool shouldGetHandRotation = false;
    private XRGrabInteractable grabInteractor => GetComponent<XRGrabInteractable>();

    private void OnEnable(){
        grabInteractor.selectEntered.AddListener(GrabbedBy);
        grabInteractor.selectExited.AddListener(GrabEnd);
    }
    private void OnDisabled(){
        grabInteractor.selectEntered.RemoveListener(GrabbedBy);
        grabInteractor.selectExited.RemoveListener(GrabEnd);
    }
    private void GrabEnd(SelectExitEventArgs arg0){
        shouldGetHandRotation = false;
        requiresStartAngle = true;
        HandModelVisibility(false);
    }
    private void GrabbedBy(SelectEnterEventArgs arg0){
        interactor = GetComponent<XRGrabInteractable>().selectingInteractor;
        interactor.GetComponent<XRDirectInteractor>().hideControllerOnSelect = true;

        shouldGetHandRotation = true;
        startAngle = 0f;
        HandModelVisibility(true);
    }
    private void HandModelVisibility(bool visibilityState){
        if(!shouldUseDummyHands){
            return;
        }
        if(interactor.CompareTag("RightHand")){
            RightHandModel.SetActive(visibilityState);
        }
    }

    void Update(){
        if(shouldGetHandRotation){
            var rotateAngle = GetInteractorRotation();
            GetRotationDistance(rotateAngle);
        }
    }

    public float GetInteractorRotation() => interactor.GetComponent<Transform>().eulerAngles.y;

    private void GetRotationDistance(float currentAngle){
        
        if(!requiresStartAngle){
            var angleDifference = Mathf.Abs(startAngle - currentAngle);
            if(angleDifference > angleTolerance){
                if(angleDifference > 270f){
                    float angleCheck;
                    if(startAngle < currentAngle){
                        angleCheck = CheckAngle(currentAngle, startAngle);
                        //honestly combine clock and anticlockwise conditionals later
                        if(angleCheck < angleTolerance){
                            return;
                        }else{
                            RotateDialClockwise();
                            startAngle = currentAngle;
                        }
                    }else if (startAngle > currentAngle){
                        angleCheck = CheckAngle(currentAngle, startAngle);
                        if(angleCheck < angleTolerance){
                            return;         
                        }else{
                            RotateDialAntiClockwise();
                            startAngle = currentAngle;
                        }
                    }
                }
                else{
                    requiresStartAngle = false;
                    startAngle = currentAngle;
                }
            }

            float CheckAngle(float currentAngle, float startAngle) => (360f - currentAngle) + startAngle;

            void RotateDialClockwise(){
                linkedDial.localEulerAngles = new Vector3(linkedDial.localEulerAngles.x,
                                                          linkedDial.localEulerAngles.y + snapRotationAmount,
                                                          linkedDial.localEulerAngles.z);
                
                if(TryGetComponent<IDial>(out IDial dial)){
                    dial.DialChanged(linkedDial.localEulerAngles.z);
                }
            }
            void RotateDialAntiClockwise(){
                linkedDial.localEulerAngles = new Vector3(linkedDial.localEulerAngles.x,
                                                          linkedDial.localEulerAngles.y - snapRotationAmount,
                                                          linkedDial.localEulerAngles.z);
                
                if(TryGetComponent<IDial>(out IDial dial)){
                    dial.DialChanged(linkedDial.localEulerAngles.z);
                }
            }
        }
    }
}
