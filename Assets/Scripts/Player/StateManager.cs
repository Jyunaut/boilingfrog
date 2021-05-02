using UnityEngine;

namespace Player
{
    public class StateManager : MonoBehaviour
    {
        public Controller controller;
        public Animator animator;
        public PlayerState playerState;
        public SpriteRenderer spriteRenderer;
        
        public bool canMove;

        private StateManager()
        {
            canMove = true;
        }

        void Awake()
        {
            controller = GetComponent<Controller>();
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
