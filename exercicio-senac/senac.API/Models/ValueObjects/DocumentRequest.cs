using Flunt.Notifications;

namespace Senac.API.Models.ValueObjects
{
    public class DocumentRequest : Notifiable
    {
        protected DocumentRequest() { }

        public DocumentRequest(string number, int type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; set; }
        public int Type { get; set; }
    }
}
