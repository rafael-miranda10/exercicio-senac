﻿using Flunt.Notifications;

namespace Senac.API.Models.ValueObjects
{
    public class DocumentUI : Notifiable
    {
        protected DocumentUI() { }

        public DocumentUI(string number, int type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get;  set; }
        public int Type { get;  set; }

    }
}
