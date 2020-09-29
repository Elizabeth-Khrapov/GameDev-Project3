using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    public Animator animator;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {

     animator = GetComponent<Animator>();
        isOpen = false;
    }

    void OnTriggerEnter(Collider other)
    {
            Debug.Log("trigger Enter");
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("DoorOpen");
            isOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger Exit");
        if (isOpen&&other.CompareTag("Player"))
        {
            animator.SetTrigger("DoorClose");
            isOpen = false;
        }
    }
}