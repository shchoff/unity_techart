using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pcontroller : MonoBehaviour
{
    Quaternion StartingRotation;
    public GameObject cam;
    public Image UIHP;
    float Ver, Hor, Jump, RotHor, RotVer;
    bool isGround;
    float CurrentSpeed = 7, JumpSpeed = 200, sensivity = 2;
    public float RunSpeed = 11, StepSpeed = 4, NormalSpeed = 7;
    public float hp = 1f;

    void Start()
    {
        StartingRotation = transform.rotation;
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "ground") ;
        {
            isGround = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }

    void Update()
    { 
        if (hp < 0)
        {
            hp = 1f;
            Application.LoadLevel(Application.loadedLevel);
        }

        UIHP.fillAmount = hp;
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            CurrentSpeed = RunSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            CurrentSpeed = StepSpeed;
        }
        else
        {
            CurrentSpeed = NormalSpeed;
        }

        RotHor += Input.GetAxis("Mouse X") * sensivity; 
        RotVer += Input.GetAxis("Mouse Y") * sensivity;

        RotVer = Mathf.Clamp(RotVer, -60, 60);

        Quaternion RotY = Quaternion.AngleAxis(RotHor, Vector3.up);
        Quaternion RotX = Quaternion.AngleAxis(-RotVer, Vector3.right);

        cam.transform.rotation = StartingRotation * transform.rotation * RotX;
        transform.rotation = StartingRotation * RotY;

        if (isGround)
        {
            Ver = Input.GetAxis("Vertical") * Time.deltaTime * CurrentSpeed;
            Hor = Input.GetAxis("Horizontal") * Time.deltaTime * CurrentSpeed;
            Jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;
            GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
        }

        transform.Translate(new Vector3(Hor, 0, Ver));
    }

    void OnTriggerStay (Collider other)
    {
        if(other.tag == "Dead")
        {
            hp = hp - 0.01f;
        }
    }
}
