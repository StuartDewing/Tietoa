using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tietoa.Domain
{
    public static class NhlConstants
    {
        public const int FirstDraftYear = 1963;
        public const string Division = "divisions";
        public const string Draft = "draft";
        public const string People = "people";
        public const string Schedule = "schedule";
        public const string Standings = "standings";
        public const string Teams = "teams";
    }


    public static class ValidationMessages 
    {
        public const string BadRequestDraftYear = "Draft year before the first draft of";
        public const string BadRequestPlayerIdMissing = "Player id missing";
    }
}
