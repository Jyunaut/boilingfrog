using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5f;
        
        public readonly PlayerInput playerInput = new PlayerInput();
        public Rigidbody2D rigidbody2d;
        public StateManager stateManager;
        public Vector2 direction { get; private set; }

        private Vector2 prevPos;

        void Awake()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
            stateManager = GetComponent<StateManager>();
        }

        void Update()
        {
            if (stateManager.canMove)
            {
                rigidbody2d.MovePosition(rigidbody2d.position + new Vector2(playerInput.Horizontal, playerInput.Vertical).normalized * speed * Time.fixedDeltaTime);
                direction = (rigidbody2d.position - prevPos).normalized;
                prevPos = rigidbody2d.position;
            }
            
            if (playerInput.Dodge)
            {
                stateManager.playerState.Dodge();
            }
        }
    }
}
