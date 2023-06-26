using Boardgames.Data.Models.Enums;
using Boardgames.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Restrictions.SellerNameMinLenght)]
        [MaxLength(Restrictions.SellerNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MinLength(Restrictions.SellerAddressMinLenght)]
        [MaxLength(Restrictions.SellerAddressMaxLenght)]
        public string Address { get; set; }

        [Required]
        public string Country  { get; set; }

        [Required]
        [RegularExpression(Restrictions.SellerWebsitePatter)]
        public string Website  { get; set; }

        [Required]
        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
