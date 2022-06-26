using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private Animator animator; //Get animator using component
        private Text commandText;  // Set Key board command
        private Text collectableMarksText; //collectable marks text
        private static int collectableMarks = 0;
        [Header("Player Speed Controllers")]
        [Range(0.1f, 3f)]
        [SerializeField] private float Speed;
        [Range(1f, 20f)]
        [SerializeField] private  float rotationSpeed;

        private bool doorOpenBool;
       
        private void Start()
        {
            animator = GetComponent<Animator>();
            doorOpenBool = false;
            commandText = GameObject.Find("CommandText").GetComponent<Text>();
            collectableMarksText = GameObject.Find("collectableMarksText").GetComponent<Text>();
        }
        private float animationSpeed;
        public float AnimationSpeed {
            get { return animationSpeed; } 
            set { Run(animationSpeed); animationSpeed = value; } }

        private float rotationPlayer;
        public float RotationPlayer
        {
            get { return rotationPlayer; }
            set { PlayerRotation(rotationPlayer); rotationPlayer = value; }
        }
        //playerrotation setting 
        private void PlayerRotation(float rotation)
        {
            transform.Rotate(0, rotation*rotationSpeed, 0);
        }
        //set animation variables to player
        //Parameter => Wal- boolk . Speed - float
        private void Run(float movement)
        {
            if (AnimationSpeed ==0)
            {
                animator.SetBool("Walk", false);
            } else
            {
                animator.SetBool("Walk", true);
                animator.SetFloat("Speed", movement*Speed);
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.tag.Equals("door")) //open the door
            {
                doorOpenBool = true;

                commandText.text = "press E to open the door";
            }
            if(other.gameObject.tag.Equals("Collectable")) //collectable identification
            {
                ++collectableMarks;
                collectableMarksText.text = collectableMarks.ToString();
                Destroy(other.gameObject);
            }
            
        }
        private void OnCollisionStay(Collision other)
        {
            if (doorOpenBool)
            {
                if (Input.GetKey(KeyCode.E) & other.gameObject.tag.Equals("door"))
                {

                    Animator anim =  other.gameObject.GetComponent<Animator>();
                    anim.runtimeAnimatorController = Resources.Load("Animation/door" , typeof(RuntimeAnimatorController))as RuntimeAnimatorController;
                    other.gameObject.GetComponent<BoxCollider>().enabled = false;
                    doorOpenBool = false;
                    commandText.text = "";
                }
            }
        }
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.tag.Equals("door"))
            {
                doorOpenBool = false;
                commandText.text = "";
            }
        }

       
        
    }
}

