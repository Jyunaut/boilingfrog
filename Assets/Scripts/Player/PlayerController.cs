using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        public readonly PlayerInput PlayerInput = new PlayerInput();
        
        private Rigidbody2D rigidbody2d;
        
        [SerializeField]
        private float speed = 5f;

        void Awake()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            // Player movement
            transform.position += new Vector3(PlayerInput.Horizontal, PlayerInput.Vertical, 0).normalized * speed * Time.deltaTime;
        }

        void Update()
        {
            if (PlayerInput.Dodge)
            {

            }
        }
    }
}
