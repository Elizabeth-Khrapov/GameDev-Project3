using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorMotion : MonoBehaviour
{
    bool isOpen;
    Animator animator;
    void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
    }

     void OnTriggerEnter(Collider other)
    {
         Debug.Log("trigger  Glass Enter");
        if(other.gameObject.tag =="Player")
        {
            isOpen = true;
            animator.SetTrigger("GlassOpen");
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(isOpen&& other.gameObject.tag == "Player")
        {
            isOpen = false;
            animator.SetTrigger("GlassClose");
        }
    }
}