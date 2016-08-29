using System;

namespace CodeCamp.Core.Models
{
    public class Speakerslist
    {
        public int attendeeId { get; set; }
        public string pkid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int presentationLimit { get; set; }
        public bool allowAttendeeToEmailMe { get; set; }
        public string userWebsite { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userZipCode { get; set; }
        public string userBio { get; set; }
        public string userBioShort { get; set; }
        public string userBioEllipsized { get; set; }
        public bool saturdayClasses { get; set; }
        public bool sundayClasses { get; set; }
        public string phoneNumber { get; set; }
        public string addressLine1 { get; set; }
        public string shirtSize { get; set; }
        public int emailSubscription { get; set; }
        public string twitterUrl { get; set; }
        public string twitterHandle { get; set; }
        public string googlePlusUrl { get; set; }
        public string googlePlusId { get; set; }
        public string linkedInUrl { get; set; }
        public string linkedInId { get; set; }
        public string facebookUrl { get; set; }
        public string facebookId { get; set; }
        public string imageUrl { get; set; }
        public string speakerLocalUrl { get; set; }
        public string company { get; set; }
        public bool isProctor { get; set; }
        public bool allowHtml { get; set; }
        public DateTime lastUpdateDate { get; set; }
    }
}