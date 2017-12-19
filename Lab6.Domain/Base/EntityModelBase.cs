using System;

namespace Lab6.Domain.Base
{
    public abstract class EntityModelBase : IEntityModel
    {
        public Guid Id { get; set; }


        protected EntityModelBase()
        {
            Id = Guid.NewGuid();
        }
    }
}