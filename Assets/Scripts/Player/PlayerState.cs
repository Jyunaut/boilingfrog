namespace Player
{
    public abstract class PlayerState : State
    {
        public StateManager stateManager;
        
        protected string stateName;

        public PlayerState(StateManager stateManager, string stateName)
        {
            this.stateManager = stateManager;
            this.stateName = stateName;
        }

        public void HandleInput(PlayerInput.Action action)
        {
            if (action == PlayerInput.Action.Dodge)
            {
                Dodge();
            }
        }

        public bool Idle()
        {
            if ((stateManager.controller.playerInput.Horizontal == 0
                && stateManager.controller.playerInput.Vertical == 0)
                && stateManager.controller.direction.magnitude == 0)
            {
                stateManager.SetState(new Idle(stateManager)); return true;
            }
                return false;
        }

        public bool Move()
        {
            if ((stateManager.controller.playerInput.Horizontal != 0
                || stateManager.controller.playerInput.Vertical != 0)
                && stateManager.controller.direction.magnitude > 0
                && stateManager.canMove)
            {
                stateManager.SetState(new Move(stateManager)); return true;
            }
            return false;
        }

        public bool Dodge()
        {
            if (stateManager.controller.playerInput.Dodge
                && stateManager.canMove)
            {
                stateManager.SetState(new Dodge(stateManager)); return true;
            }
            return false;
        }
    }
}