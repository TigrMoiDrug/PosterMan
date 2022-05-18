using System;
using System.Text.RegularExpressions;

namespace ExploringCalifornia2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        private string _dateTimeStamp;
        public string DateTimeStamp
        {
            get
            {
                return _dateTimeStamp;
            }
            set
            {
                _dateTimeStamp = value;
            }
        }
    }
}
