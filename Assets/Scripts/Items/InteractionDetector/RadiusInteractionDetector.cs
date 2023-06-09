﻿using System;
using UnityEngine;

namespace Items.InteractionDetector
{
    public class RadiusInteractionDetector : MonoBehaviour, IInteractionDetector
    {
        [SerializeField] private float radius = 1;
        private GameObject objectEntered;
        private bool isEntered;
        
        public event Action<GameObject> Interacted;

        private void Update()
        {
            CheckPicker();
            
            if (Input.GetKeyDown(KeyCode.E) && isEntered)
                Interacted?.Invoke(objectEntered);
        }

        private void CheckPicker()
        {
            isEntered = false;
            foreach (var col in Physics2D.OverlapCircleAll(transform.position, radius))
                if (col.gameObject.TryGetComponent<Player.Player>(out var picker))
                {
                    isEntered = true;
                    objectEntered = col.gameObject;
                    break;
                }
        }
    }
}