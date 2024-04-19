using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // [SerializeField] private List<string> InteractableType = new List<string>(){"Crate", "Door"};
    [SerializeField] private string InteractableType;

    public void Interact(){
        Debug.Log("L'objet a été interacté");

        switch (InteractableType){
            case "crate":
            CrateInteract();
            break;

            case "door":
            DoorInteract();
            break;
        }
    }
    private void DoorInteract(){
        Debug.Log("Interaction: Door");
        bool isDoorOpen = transform.eulerAngles.y == 90;
        Vector3 rotationVector = transform.eulerAngles;
        rotationVector.y = isDoorOpen ? 0 : 90;
        transform.eulerAngles = rotationVector;
    }

    private void CrateInteract(){
        Debug.Log("Interaction: Crate");
    }
}
