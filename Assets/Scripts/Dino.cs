using UnityEngine;

namespace Dino.Game
{
    public class Dino : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private float jumpForce;

        [SerializeField]
        private float distanceToGround = 0.025f;

        [SerializeField]
        private LayerMask floorLayer;

        private bool isRunning;
        private bool isGrounded;
        private Rigidbody2D rb;
        private Animator animator;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (isRunning)
            {
                transform.position += speed * Time.deltaTime * Vector3.right;
            }

            if (!isGrounded)
            {
                isGrounded = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, floorLayer);

                if (isGrounded)
                {
                    animator.SetBool("isGrounded", true);
                }
            }
        }

        public void Jump()
        {
            if (!isGrounded) return;

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isGrounded", false);
        }

        public void StartRunning()
        {
            isRunning = true;
            animator.SetBool("isWalking", true);
        }
    }
}