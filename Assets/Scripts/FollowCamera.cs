using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject target; //récupérer la référence de l'objet à suivre
    [SerializeField] private float cameraDistance = 12f; //définir la distance statique sur l'axe y

    void Start() //première frame
    {
        MatchPosition();
    }
    void Update() // chaque nouvelle frame
    {
        MatchPosition();
    }
    private void MatchPosition()
    {   // donner à la position actuelle une nouvelle position extraite de l'objet à suivre + axe y fixe
        transform.position = new Vector3(target.transform.position.x, cameraDistance, target.transform.position.z);
    }

}
