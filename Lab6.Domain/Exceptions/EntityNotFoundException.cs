using System;

namespace Lab6.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type, object id)
            : base($"Entity type [{type.Name}] with id [{id}] not found.")
        {
            
        }


        public static void ThrowIfNull<T>(T target, object id)
        {
            if (target == null)
            {
                throw New<T>(id);
            }
        }

        public static EntityNotFoundException New<T>(object id)
        {
            return new EntityNotFoundException(typeof(T), id);
        }
    }
}