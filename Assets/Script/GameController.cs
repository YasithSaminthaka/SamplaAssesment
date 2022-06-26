using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        
       
        private float mouseValue; //mouse pointe x value

        Player player;

        void Start()
        {
            player = new PlayerManager(playerController);
        }

        void Update()
        {
            player.Run(Input.GetAxis("Mouse X"));
            player.ChangeSpeed(Input.GetAxis("Vertical"));
        }
        
    }

}
