using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [ForeignKey("Boardgame")]
        public int BoardgameId { get; set; }
        public Boardgame Boardgame { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
