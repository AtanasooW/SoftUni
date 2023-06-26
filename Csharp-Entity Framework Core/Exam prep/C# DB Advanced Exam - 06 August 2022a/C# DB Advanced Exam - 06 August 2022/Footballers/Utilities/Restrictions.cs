using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Utilities
{
    public class Restrictions
    {
        //FOOTBALLER

        //⦁	Name 
        public const int FootballerNameMinLenght = 2;
        public const int FootballerNameMaxLenght = 40;
        //⦁	Position 
        public const int FootballerPositionMinRange = 0;
        public const int FootballerPositionMaxRange = 3;
        //⦁	BestSkill 
        public const int FootballerBestSkillMinRange = 0;
        public const int FootballerBestSkillMaxRange = 4;


        //TEAM

        //⦁	Name 
        public const int TeamNameMinLenght = 3;
        public const int TeamNameMaxLenght = 40;
        public const string TeamNamePatter = @"^[A-Za-z0-9\s\.\-]{3,}$";
        //⦁	Nationality 
        public const int TeamNationalityMinLenght = 2;
        public const int TeamNationalityMaxLenght = 40;

        //COACH
        //⦁	Name 
        public const int CoachNameMinLenght = 2;
        public const int CoachNameMaxLenght = 40;


    }
}
