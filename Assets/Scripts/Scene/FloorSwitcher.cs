using System;
using Model;
using UnityEngine;

namespace Scene
{
    public class FloorSwitcher : MonoBehaviour
    {
        [SerializeField]
        private GameObject floor1;

        private SpriteRenderer[] floor1Sprites;

        private float floor1Alpha;
    
        [SerializeField]
        private GameObject floor2;
    
        private SpriteRenderer[] floor2Sprites;

        private float floor2Alpha;

    
        private void Start()
        {
            floor1Sprites = floor1.GetComponentsInChildren<SpriteRenderer>();
            floor2Sprites = floor2.GetComponentsInChildren<SpriteRenderer>();

            if (Core.HouseState.CurrentFloor == 1)
                TurnOn1Floor();
            else
                TurnOn2Floor();
        }

        private void Update()
        {
            foreach (var sprite in floor1.GetComponentsInChildren<SpriteRenderer>())
            {
                var color = sprite.color;
                color.a = floor1Alpha;
                sprite.color = color;
            }
        
            foreach (var sprite in floor2.GetComponentsInChildren<SpriteRenderer>())
            {
                var color = sprite.color;
                color.a = floor2Alpha;
                sprite.color = color;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            floor1.SetActive(true);
            floor2.SetActive(true);
        }

        private void TurnOn1Floor()
        {
            floor1Alpha = 1;
            floor2Alpha = 0;
            floor1.SetActive(true);
            floor2.SetActive(false);
        }
        
        private void TurnOn2Floor()
        {
            floor1Alpha = 0;
            floor2Alpha = 1;
            floor1.SetActive(false);
            floor2.SetActive(true);
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            var alpha = (col.gameObject.transform.position.y - transform.position.y)
                        / (GetComponent<BoxCollider2D>().size.y * transform.localScale.y) 
                        + 0.5f;

            alpha = Math.Clamp(alpha, 0, 1);
            alpha *= alpha;

            floor1Alpha = 1 - alpha;
            floor2Alpha = alpha;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (floor1Alpha > 0.5)
            {
                floor1.SetActive(true);
                floor2.SetActive(false);
                Core.HouseState.CurrentFloor = 1;
            }
            else
            {
                floor1.SetActive(false);
                floor2.SetActive(true);
                Core.HouseState.CurrentFloor = 2;
            }
        }
    }
}
