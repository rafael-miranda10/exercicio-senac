using Flunt.Notifications;
using System;

namespace Senac.Domain.BaseEntity
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
        }

        public Guid Id { get; set; }
    }
}
