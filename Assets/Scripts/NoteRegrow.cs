using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRegrow : MonoBehaviour
{
    public GameObject NotePrefab;
    public Transform ParentTransform;
    public bool used;

   public void regrowNote(int positionSlot)
   {
    if(used){
        return;
    }
    GameObject newNote = Instantiate(NotePrefab);
    newNote.GetComponent<Transform>().parent = ParentTransform;
    Vector3 PositionSlotToVector = assignVector(positionSlot);
    newNote.GetComponent<Transform>().position = ParentTransform.TransformPoint(PositionSlotToVector);
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
