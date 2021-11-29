using Flunt.Notifications;
using System;

namespace Projeto.Shared.Entities
{
    public class Base : Notifiable<Notification>
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
