using UnityEngine;

namespace Player
{
    class Idle : PlayerState
    {
        public Idle(Controller controller) : base(controller, "Idle") {}

        public override void DoStateBehaviour()
        {
            //stateManager.animator.Play(stateName);
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

        public Move(Controller controller) : base(controller, "Move") {}

        public override void DoStateBehaviour()
        {
            //stateManager.animator.Play(stateName);
            controller.rigidbody2d.MovePosition(controller.rigidbody2d.position + new Vector2(controller.playerInput.Horizontal, controller.playerInput.Vertical).normalized * controller.speed * Time.fixedDeltaTime);
            controller.direction = (controller.rigidbody2d.position - prevPos).normalized;
            prevPos = controller.rigidbody2d.position;
            controller.spriteRenderer.color = new UnityEngine.Color(127, 0, 0);
        }

        public override void Transitions()
        {
            if      (Dodge()) {}
            else if (Idle())  {}
        }
    }

    class Dodge : PlayerState
    {
        public Dodge(Controller controller) : base(controller, "Dodge") {}

        public override void DoStateBehaviour()
        {
            //stateManager.animator.Play(stateName);
        }

        public override void Transitions()
        {
            if      (Move()) {}
            else if (Idle()) {}
        }
    }
}