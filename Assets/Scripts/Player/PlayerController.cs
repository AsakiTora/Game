using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Reference")]
    private CharacterController controller;
    public Animator animator;
    public Camera mainCam;

    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float swipSpeed;

    private Transform localTrans;
    private Vector3 lastMousePos;
    private Vector3 mousePos;
    private Vector3 newPosForTrans;

    

    private void Start()
    {
        localTrans = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetFloat("Run", speed);
        }
        else
        if (Input.GetMouseButton(0))
        {
            mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            float xDiff = mousePos.x - lastMousePos.x;
            Debug.Log(xDiff);
            Debug.Log(mousePos);

            newPosForTrans.x = localTrans.position.x + xDiff * swipSpeed * Time.deltaTime;
            newPosForTrans.y = localTrans.position.y;
            newPosForTrans.z = localTrans.position.z;

            localTrans.position = newPosForTrans + localTrans.forward * speed * Time.deltaTime;
            lastMousePos = mousePos;
        }
        else
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetFloat("Run", 0);
        }
        
    }

 
}
