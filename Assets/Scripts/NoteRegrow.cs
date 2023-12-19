using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRegrow : MonoBehaviour
{
    //The note that will be being replaced
    public GameObject NotePrefab;
    //the Transform component of the parent of the object
    public Transform ParentTransform;
    //bool to determine if the note can be reused or not
    public bool used;

   //The function regrowNoteis designed to place the correct ball 
   public void regrowNote(int positionSlot)
   {
    //check if used is true, and end the funciton if it is
    if(used){
        return;
    }
    //generate a new note based on the prefab
    GameObject newNote = Instantiate(NotePrefab);
    //set the new notes parent
    newNote.GetComponent<Transform>().parent = ParentTransform;
    //define the new position to place the note
    Vector3 PositionSlotToVector = assignVector(positionSlot);
    //set the new note to the positionSlotToVector, making sure it is relative to the parent's position.
    newNote.GetComponent<Transform>().position = ParentTransform.TransformPoint(PositionSlotToVector);
    //Remove the note's ability to replicate
    used = true;
   }

   public Vector3 assignVector(int positionSlot){
    switch(positionSlot){
        case 3:
            return new Vector3(0.253f, -0.002f, 0.055f);
        case 2:
            return new Vector3(0.152f, -0.002f, 0.055f);
        case 1:
            return new Vector3(0.051f, -0.002f, 0.055f);
    }
    return new Vector3(0.0051f, -0.002f, 0.055f);
   }
}
