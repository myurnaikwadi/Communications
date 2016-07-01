using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindleSpur.Models.Interfaces;

namespace KindleSpur.Models
{
    public class Feedback : IFeedback
    {
        public string Sender { get; set; }
        public string FeedbackText { get; set; }
        public DateTime CreateDate { get; set; }
        public int Rating { get; set; }
    }
}