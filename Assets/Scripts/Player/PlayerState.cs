namespace Player
{
    public abstract class PlayerState : State
    {
        public Controller controller;
        
        protected string stateName;

        public PlayerState(Controller stateManager, string stateName)
        {
            this.controller = stateManager;
            this.stateName = stateName;
        }

        public bool Idle()
        {
            if ((controller.playerInput.Horizontal == 0
                && controller.playerInput.Vertical == 0)
                && controller.direction.magnitude == 0)
            {
                controller.SetState(new Idle(controller)); return true;
            }
                return false;
        }

        public bool Move()
        {
            if ((controller.playerInput.Horizontal != 0
                || controller.playerInput.Vertical != 0)
                && controller.canMove)
            {
                controller.SetState(new Move(controller)); return true;
            }
            return false;
        }

        public bool Dodge()
        {
            if (controller.playerInput.Dodge
                && controller.canMove)
            {
                controller.SetState(new Dodge(controller)); return true;
            }
            return false;
        }
    }
}