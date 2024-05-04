using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    ClickToMove clickToMove;
    IEnumerator interactRoutine;
    Interactable currentInteractable;
    // Start is called before the first frame update
    void Start()
    {
        clickToMove = GetComponent<ClickToMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            Interactable interactable;
            hit.collider.TryGetComponent<Interactable>(out interactable);
            if (interactable != null){
                Debug.Log("Objeto interactivo: " + interactable.objectType);

                if(Input.GetMouseButtonDown(0)){
                    interactRoutine = Interact(interactable);
                    StartCoroutine(interactRoutine);
                }
            }
            else if(clickToMove.CursorOnGround()){
                //Debug.Log("CursorOnGround");
            }
            else{
                //Debug.Log("Nada");
            }
        }
        else{
            //Debug.Log("Nada");
        }
    }

    IEnumerator Interact(Interactable interactable){
        bool walking = true;
        clickToMove.agent.SetDestination(interactable.transform.position);
        yield return new WaitForSeconds(0.1f);
        while(walking){
            if(clickToMove.agent.remainingDistance > 2){
                yield return null;
            }
            else{
                walking = false;
                clickToMove.agent.SetDestination(transform.position);
            }
        }

        interactable.Interact();
        currentInteractable = interactable;
    }

    public void CancelInteraction(){
        StopCoroutine(interactRoutine);
        currentInteractable.isInteracting = false;
        currentInteractable = null;
    }
}
