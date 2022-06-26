using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample.Controller
{
    public class PlayerManager : Player
    {
        PlayerController player;

        public PlayerManager(PlayerController player)
        {
            this.player = player;
        }

        public PlayerManager()
        {

        }
        public void ChangeSpeed(float value)
        {
            player.AnimationSpeed = value;
        }

        public void GetItem()
        {
            throw new System.NotImplementedException();
        }

        public void Run(float value)
        {
            player.RotationPlayer = value;
        }
      
    }
}

