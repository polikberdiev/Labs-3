namespace Lab6.Domain.Base
{
    public abstract class StateEntityModelBase : EntityModelBase, IStateModel
    {
        public State State { get; set; }


        protected StateEntityModelBase()
        {
            State = State.Active;
        }
    }
}