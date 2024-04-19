using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 13f;
    [SerializeField]private float rotateSpeed = 5f;
    // Start is called before the first frame update
    [SerializeField]private Animator playerAnimator;
    private bool playerIsWalking = false;
    [SerializeField]private Interactable InteractableTarget;
    private PlayerInputActions playerInputActions;
    void Awake()
    {
        playerInputActions = new PlayerInputActions(); // Créer une instance de l'inputmanager
        playerInputActions.Player.Enable(); // Activer le mapping nommé "Player"
        playerInputActions.Player.Use.performed += UseInputHandler;
    }
    void Start()
    {
        
    }
    void Update()
    {
        MovementHandler();
        InteractionHandler();
    }
    void InteractionHandler(){
        // récupérer l'orientation souhaitée du joueur
        Vector3 playerOrientation = transform.forward;

        // envoyer un rayon Raycast pour détecter les interactions possibles ET récupérer l'objet touché
        if(Physics.Raycast(transform.position, playerOrientation, out RaycastHit hitObj, 10f, LayerMask.GetMask("Usables"))){
            // -- afficher un message debug "touché2"
            Debug.Log("touché" + hitObj.transform.name);

            // vérifier si l'objet touché contient un composant "interactable (que l'on a créé et associé)
            if(hitObj.transform.TryGetComponent<Interactable>(out Interactable interactableObj)){
                // si oui, appeler sa méthode "Interact"
                // interactableObj.Interact();
                InteractableTarget = interactableObj;
            } 

            if(hitObj.transform.TryGetComponent<Powerup>(out Powerup powerupObj)){
                powerupObj.Pickup();

        }}else {InteractableTarget = null;}

    }
    void UseInputHandler (InputAction.CallbackContext context)
    {
        InteractableTarget?.Interact();
        if(InteractableTarget != null) {
            playerAnimator.SetTrigger("is_using");
        }
        
    }
    void MovementHandler()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        Vector3 moveVector = new Vector3(inputVector.x, 0f, inputVector.y);
        // Le Vector3 représente un objet 3D, il est sur l'axe xyz (/!\ l'axe y du Vecteur2 devient le z du Vecteur3)

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * 2.2f, 2.7f, moveVector, moveSpeed * Time.deltaTime);

        if(canMove)
        {
            playerIsWalking = (moveVector != Vector3.zero);
            playerAnimator.SetBool("is_walking", playerIsWalking);

            transform.position = transform.position + moveVector * Time.deltaTime * moveSpeed;
        }else{
            InteractableTarget = null;
            }

        transform.forward = Vector3.Slerp(transform.forward, moveVector, Time.deltaTime * rotateSpeed);
        // Le Slerp permet de décomposer
        // Le Time.DeltaTime permet de corriger les FPS sur une seconde -> ça réduit la rapidité
    }
}
