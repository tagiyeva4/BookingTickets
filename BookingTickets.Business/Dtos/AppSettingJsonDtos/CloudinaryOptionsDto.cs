using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.Business.Dtos.AppSettingJsonDtos
{
    public class CloudinaryOptionsDto
    {
        public string APIKey { get; set; } = null!;
        public string APISecret { get; set; } = null!;
        public string CloudName { get; set; } = null!;

    }
}
