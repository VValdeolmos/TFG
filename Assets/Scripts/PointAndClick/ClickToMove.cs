using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public LayerMask groundLayer;
    public NavMeshAgent agent;
    bool cursorOnGround;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            if(((1 << hit.collider.gameObject.layer) & groundLayer) != 0){
            cursorOnGround = true;
            if(Input.GetMouseButtonDown(0)){
                agent.SetDestination(hit.point);
            }
        }
        else {
            cursorOnGround = false;
        }
        }
        else{
            cursorOnGround = false;
        }
    }

    public bool CursorOnGround(){
        return cursorOnGround;
    }
}
