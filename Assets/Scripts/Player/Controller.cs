using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        public readonly PlayerInput playerInput = new PlayerInput();
        public Rigidbody2D rigidbody2d;
        public Animator animator;
        public SpriteRenderer spriteRenderer;
        public PlayerState playerState;

        public float speed;
        public bool canMove;
        [HideInInspector]
        public Vector2 direction;

        private Controller()
        {
            speed = 5f;
            canMove = true;
            direction = new Vector2();
        }

        void Awake()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            SetState(new Idle(this));
        }

        public void SetState(PlayerState state)
        {
            if (playerState != null)
                playerState.ExitState();

            playerState = state;
            playerState.EnterState();
        }

        void Update()
        {
            playerState.DoStateBehaviour();
            playerState.Transitions();
        }
    }
}
