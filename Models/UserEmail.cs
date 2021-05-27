using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFShapBot.Models
{
    //public class UserEmail: BaseUser

    //{
    //    public UserEmail(string NikeName, long ChatId) : base(NikeName, ChatId)
    //    {
    //    }
    //}
    public class UserEmail : IEquatable<UserEmail>
    {

        public UserEmail(string NikeName, long ChatId)
        {
            id = ChatId;
            nike = NikeName;

            Messages = new ObservableCollection<string>();
        }

        private int count = 0;

        public int Сount
        {
            get => count;
            set => count = value;
        }
        private long id;

        public long ID
        {
            get => this.id;
            set
            {
                this.id = value;
            }


        }

        private string nike;


        public string Nike
        {
            get => nike;
            set
            {
                nike = value;


            }
        }

        public bool Equals(UserEmail other)
        {
            return other.ID == id;
        }

        public ObservableCollection<string> Messages { get; set; }

        public void AddMessage(string Text)
        {
            Messages.Add(Text);
        }



    }
}
