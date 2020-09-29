using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public string[] positionsTags;
    public Vector3 destination;
    public Transform agentTransform;
    public Vector3 agentCurrentPosition;

    // Start is called before the first frame update
    void Start()
    {
        agentTransform = GetComponent<Transform>();
        agent.updateRotation = false;
        initPositions();
        setNewDestination();

    }

    // Update is called once per frame
    void Update()
    {
        agentCurrentPosition  = agentTransform.position;
       handleAgentDestination();
        if(agent.remainingDistance >agent.stoppingDistance){
             character.Move(agent.desiredVelocity, false,false);
        }else{
            character.Move(Vector3.zero,false,false);
        }
        
    }
    void initPositions(){
    positionsTags = new string[]{"SofaYellow","Toilet",
    "Bed","Terrace","SofaWhite","PlateWithFruit","Table"};
    }
    
     void handleAgentDestination()
    {
        if (Mathf.Abs(agentCurrentPosition.x - destination.x) < 1 && Mathf.Abs(agentCurrentPosition.z - destination.z) < 1)
        {
            setNewDestination();
        }
    }
    void setNewDestination(){
        //Random rnd = new Random();
        int indexForTarget = Random.Range(0,7);
        Debug.Log(indexForTarget);
        destination = GameObject.FindWithTag(positionsTags[indexForTarget]).transform.position;
        agent.SetDestination(destination);
    }
}
