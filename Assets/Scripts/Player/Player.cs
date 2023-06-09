using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private const float speed = 5;
    
        private new Rigidbody2D rigidbody;
    
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var xAxis = Input.GetAxisRaw("Horizontal");
            var yAxis = Input.GetAxisRaw("Vertical");

            rigidbody.velocity = new Vector2(xAxis, yAxis).normalized * speed;
        }
    }
}
