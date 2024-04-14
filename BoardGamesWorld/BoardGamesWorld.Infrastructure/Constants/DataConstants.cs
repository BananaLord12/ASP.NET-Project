using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Infrastructure.Constants
{
    public static class DataConstants
    {
        //Board Game

        public const int BoardGameNameMaxLength = 100;
        public const int BoardGameNameMinLength = 5;

        public const int BoardGamesDescMaxLength = 300;
        public const int BoardGmaesDescMinLength = 50;

        //Contributor

        public const int ContributorNameMaxLength = 13;
        public const int ContributorNameMinLength = 3;
        public const int ContributorPhoneNumberMaxLength = 15;
        public const int ContributorPhoneNumberMinLength = 3;

        //Organizer

        public const int OrganizerNameMaxLength = 13;
        public const int OrganizerNameMinLength = 3;
        public const int OrganizerPhoneNumberMaxLength = 15;
        public const int OrganizerPhoneNumberMinLength = 3;

        //Event

        public const int EventNameMaxLength = 35;
        public const int EventNameMinLength = 10;
        public const int EventDescMaxLength = 200;
        public const int EventDescMinLength = 25;
        public const string DateFormat = "dd/MM/yyyy HH:mm";

        //Category

        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 3;

        //Theme

        public const int ThemeNameMaxLength = 20;
        public const int ThemeNameMinLength = 5;

        //Application User
        //First name

        public const int UserFirstNameMaxLength = 12;
        public const int UserFirstNameMinLength = 1;

        //Second Name

        public const int UserLastNameMaxLength = 15;
        public const int UserLastNameMinLength = 3;
    }
}
