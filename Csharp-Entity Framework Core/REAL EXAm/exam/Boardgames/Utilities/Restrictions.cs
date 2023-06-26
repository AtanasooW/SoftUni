using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Utilities
{
    public class Restrictions
    {
        // Boardgame

        //⦁	Name 
        public const int BoardgameNameMinLenght = 10;
        public const int BoardgameNameMaxLenght = 20;
        //⦁	Rating  
        public const double BoardgameRatingMinLenght = 1;
        public const double BoardgameRatingMaxLenght = 10.00;
        //⦁YearPublished  
        public const int BoardgameYearPublishedMinRange = 2018;
        public const int BoardgameYearPublishedMaxRange = 2023;
        //⦁CategoryType   
        public const int BoardgameCategoryTypeMinRange = 0;
        public const int BoardgameCategoryTypeMaxRange = 4;


        //Seller

        //⦁	Name 
        public const int SellerNameMinLenght = 5;
        public const int SellerNameMaxLenght = 20;
        //⦁	Address  
        public const int SellerAddressMinLenght = 2;
        public const int SellerAddressMaxLenght = 30;
        //Website
        public const string SellerWebsitePatter = @"^www\.[a-zA-Z0-9\-]+\.com$";

        //Creator
        public const int CreatorFirstNameMinLenght = 2;
        public const int CreatorFirstNameMaxLenght = 7;
        //lastName
        public const int CreatorLastNameMinLenght = 2;
        public const int CreatorLastNameMaxLenght = 7;
    }
}
