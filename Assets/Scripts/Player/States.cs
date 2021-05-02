using UnityEngine;

namespace Player
{
    class Idle : PlayerState
    {
        public Idle(Controller controller) : base(controller, "Idle") {}

        public override void DoStateBehaviour()
        {
            controller.spriteRenderer.color = new UnityEngine.Color(255, 255, 255);
        }

        public override void Transitions()
        {
            if      (Dodge()) {}
            else if (Move())  {}
        }
    }

    class Move : PlayerState
    {
        private Vector2 prevPos;
        private float timer;

        public Move(Controller controller) : base(controller, "Move") {}

        public override void DoStateBehaviourFixedUpdate()
        {
            MovePlayer();
            controller.spriteRenderer.color = new UnityEngine.Color(127, 0, 0);
        }

        public override void Transitions()
        {
            if      (Dodge()) {}
            else if (Idle())  {}
        }

        private void MovePlayer()
        {
            controller.direction = new Vector2(controller.playerInput.Horizontal, controller.playerInput.Vertical).normalized;
            controller.rigidbody2d.MovePosition(controller.rigidbody2d.position + controller.direction * controller.speed * Time.fixedDeltaTime);
            prevPos = controller.rigidbody2d.position;
        }
    }

    class Dodge : PlayerState
    {
        private float dodgeSpeed = 0.5f;
        private float dodgeTimer;

        public Dodge(Controller controller) : base(controller, "Dodge") {}

        public override void EnterState()
        {
            controller.DisableMovement();

            dodgeTimer = 0.5f;
        }

        public override void DoStateBehaviourFixedUpdate()
        {
            controller.spriteRenderer.color = new UnityEngine.Color(0, 127, 0);
            controller.rigidbody2d.MovePosition(controller.rigidbody2d.position + controller.direction * dodgeSpeed * dodgeTimer);
            dodgeTimer -= Time.fixedDeltaTime;
            if (dodgeTimer <= 0) ExitState();
        }

        public override void ExitState()
        {
            controller.EnableMovement();
        }

        public override void Transitions()
        {
            if (dodgeTimer > 0) return;
            if      (Move()) {}
            else if (Idle()) {}
        }
    }
}