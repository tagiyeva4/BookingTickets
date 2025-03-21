using BookingTickets.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.Core.ViewModels
{
   public class BlogDetailVm
    {
        public bool HasCommentUser { get; set; }
        public int TotalCommentsCount { get; set; }
        public BlogComment BlogComment { get; set; }
    }
}
