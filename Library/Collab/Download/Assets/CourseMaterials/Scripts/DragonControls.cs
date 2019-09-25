//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DragonControls : MonoBehaviour {

//    // Use this for initialization

//    public GameObject Dragon;
//    public Transform cam;
//    public float moveSpeed;
//    public Joystick joystick;
//    public AudioSource audioSource;
//    public AudioClip m1;
//    public AudioClip m2;
//    public AudioClip m3;
//    public AudioClip i1;
//    public AudioClip i2;
//    public AudioClip i3;
//    Vector2 input;
//    Vector3 movDir;
//    Quaternion rotation;
//    Animator anim;
//    float firstDelay = 10;
//    float distance;
//    int choice;

//    void Start()
//    {
//        anim = Dragon.GetComponent<Animator>();
//    }


//    void Update()
//    {
//        //Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;
//        //Dragon.transform.Translate(Vector3.forward * Mathf.Clamp( joystick.Vertical*6 , -1,1)* moveSpeed * Time.deltaTime);
//        //Dragon.transform.Rotate(Vector3.up * joystick.Horizontal * 66 * Time.deltaTime);
//        choice = Random.Range(1, 4);
//        anim.SetInteger("walk", 0);
//        input = new Vector2(joystick.Horizontal, joystick.Vertical);
//        input = input.normalized;
//        Vector3 camF = cam.forward;
//        Vector3 camR = cam.right;
//        camF.y = 0; camR.y = 0;
//        camF = camF.normalized; camR = camR.normalized;
//        movDir = camF * input.y + camR * input.x;
//        Dragon.transform.position += movDir * Time.deltaTime * moveSpeed;
//        if (!audioSource.isPlaying)
//        {
//            switch (choice)
//            {
//                case 1:
//                    audioSource.clip = i1;
//                    break;
//                case 2:
//                    audioSource.clip = i2;
//                    break;
//                case 3:
//                    audioSource.clip = i3;
//                    break;
//            }
//        }
//        if (input != Vector2.zero)
//        {
//            rotation = Quaternion.LookRotation(movDir, Vector3.up);
//            Dragon.transform.rotation = rotation;
//            anim.SetInteger("walk", 1);
//            distance = Vector3.Distance(cam.transform.position, Dragon.transform.position);
//            anim.SetFloat("speed", 1.3f - 0.0065f * distance);
//            if (!audioSource.isPlaying)
//            {
//                switch (choice)
//                {
//                    case 1:
//                        audioSource.clip = m1;
//                        break;
//                    case 2:
//                        audioSource.clip = m2;
//                        break;
//                    case 3:
//                        audioSource.clip = m3;
//                        break;
//                }
//            }
//        }
//        if (!audioSource.isPlaying)
//        {
//            audioSource.PlayDelayed(firstDelay);
//            firstDelay = 0;
//        }
//    }

//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonControls : MonoBehaviour
{

    // Use this for initialization

    public GameObject Dragon;
    public Transform cam;
    public float moveSpeed;
    public Joystick joystick;
    public AudioSource audioSource;
    public AudioClip m1;
    public AudioClip m2;
    public AudioClip m3;
    public AudioClip i1;
    public AudioClip i2;
    public AudioClip i3;
    Vector2 input;
    Vector3 movDir;
    Quaternion rotation;
    Animator anim;
    float firstDelay = 15;
    float distance;
    int choice;
    float rotSpeed;

    void Start()
    {
        anim = Dragon.GetComponent<Animator>();
        rotSpeed = 1.5f;
    }


    void Update()
    {
        //Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;
        //Dragon.transform.Translate(Vector3.forward * Mathf.Clamp( joystick.Vertical*6 , -1,1)* moveSpeed * Time.deltaTime);
        //Dragon.transform.Rotate(Vector3.up * joystick.Horizontal * 66 * Time.deltaTime);
        choice = Random.Range(1, 4);
        anim.SetInteger("walk", 0);
        input = new Vector2(joystick.Horizontal, joystick.Vertical);
        input = input.normalized;
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        camF.y = 0; camR.y = 0;
        camF = camF.normalized; camR = camR.normalized;
        movDir = camF * input.y + camR * input.x;
        Dragon.transform.position += movDir * Time.deltaTime * moveSpeed;
        distance = Vector3.Distance(cam.transform.position, Dragon.transform.position);
        if (!audioSource.isPlaying)
        {
            switch (choice)
            {
                case 1:
                    audioSource.clip = i1;
                    break;
                case 2:
                    audioSource.clip = i2;
                    break;
                case 3:
                    audioSource.clip = i3;
                    break;
            }
        }
        if (input != Vector2.zero)
        {
            rotation = Quaternion.LookRotation(movDir, Vector3.up);

            Dragon.transform.rotation = Quaternion.Lerp(Dragon.transform.rotation, rotation, Time.deltaTime * rotSpeed);

            anim.SetInteger("walk", 1);
            anim.SetFloat("speed", 1.3f - 0.0065f * distance);
            if (!audioSource.isPlaying)
            {
                switch (choice)
                {
                    case 1:
                        audioSource.clip = m1;
                        break;
                    case 2:
                        audioSource.clip = m2;
                        break;
                    case 3:
                        audioSource.clip = m3;
                        break;
                }
            }
        }
        if (!audioSource.isPlaying)
        {
            audioSource.volume = 1 - 0.04f * distance;
            audioSource.PlayDelayed(firstDelay);
            firstDelay = 0;
        }
    }

}
