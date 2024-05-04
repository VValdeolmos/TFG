using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public LayerMask groundLayer;
    public NavMeshAgent agent;
    bool cursorOnGround;

    public GameObject pauseMenu;

    public bool estaEnDialogo = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!estaEnDialogo){
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
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                // hacemos visible el cursor
                estaEnDialogo = true;
            }
        if (Input.GetKeyDown(KeyCode.Q))
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                // hacemos visible el cursor
                estaEnDialogo = false;
            }
    }

    public bool CursorOnGround(){
        return cursorOnGround;
    }
}
