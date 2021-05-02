using UnityEngine;

namespace Player
{
    class Idle : PlayerState
    {
        public Idle(StateManager stateManager) : base(stateManager, "Idle") {}

        public override void DoStateBehaviour()
        {
            //stateManager.animator.Play(stateName);
            stateManager.spriteRenderer.color = new UnityEngine.Color(255, 255, 255);
        }

        public override void Transitions()
        {
            if      (Dodge()) {}
            else if (Move())  {}
        }
    }

    class Move : PlayerState
    {
        public Move(StateManager stateManager) : base(stateManager, "Move") {}

        public override void DoStateBehaviour()
        {
            //stateManager.animator.Play(stateName);
            stateManager.spriteRenderer.color = new UnityEngine.Color(127, 0, 0);
        }

        public override void Transitions()
        {
            if      (Dodge()) {}
            else if (Idle())  {}
        }
    }

    class Dodge : PlayerState
    {
        public Dodge(StateManager stateManager) : base(stateManager, "Dodge") {}

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