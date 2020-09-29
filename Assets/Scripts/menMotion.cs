using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menMotion : MonoBehaviour
{
    float speed;
    float angularSpeed;
    float hMove, vMove;
    CharacterController cController;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        angularSpeed = 100f;
        cController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if a key was pressed
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            hMove = Input.GetAxis("Horizontal") * angularSpeed * Time.deltaTime;
            vMove = Input.GetAxis("Vertical")* speed * Time.deltaTime;
            GetComponent<Animation>().Play("walkingMan");
            transform.Rotate(0, hMove, 0);
            // pos is the x-z coordinate of a character
            Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
            //Vector3 point;
          //  point.y = Terrain.activeTerrain.SampleHeight(pos) - transform.position.y; // delta in Y direction
            Vector3 direction = Vector3.forward * vMove ;
            //direction.y = point.y;

            transform.Translate(Vector3.forward * vMove);
            // TransformDirection transforms coordinates to GLOBALs
            cController.Move(transform.TransformDirection(direction));
        }
        else
        {
          GetComponent<Animation>().Play("idle");
        }
    }
}
