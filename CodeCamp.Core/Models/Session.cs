﻿using System;

namespace CodeCamp.Core.Models
{
    public class Session
    {
        public int codeCampYearId { get; set; }
        public int sessionLevel_id { get; set; }
        public string username { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool approved { get; set; }
        public DateTime createdate { get; set; }
        public DateTime updatedate { get; set; }
        public string adminComments { get; set; }
        public bool doNotShowPrimarySpeaker { get; set; }
        public int lectureRoomsId { get; set; }
        public int sessionTimesId { get; set; }
        public string tweetLine { get; set; }
        public DateTime tweetLineTweetedDate { get; set; }
        public bool tweetLineTweeted { get; set; }
        public string sessionsMaterialUrl { get; set; }
        public string tweetLinePreCamp { get; set; }
        public string boxFolderIdString { get; set; }
        public string boxFolderEmailInAddress { get; set; }
        public bool sessionTimePinned { get; set; }
        public bool sessionRoomPinned { get; set; }
        public string confRegistrationLine { get; set; }
        public int maxAttendance { get; set; }
        public string descriptionShort { get; set; }
        public string sessionTimeCustom { get; set; }
        public int sessionCategoryId { get; set; }
        public string notesToSpeaker { get; set; }
        public bool allowHtml { get; set; }
        public bool kidSession { get; set; }
        public string registrationCustomLink { get; set; }
        public string registrationCustomLinkName { get; set; }
        public bool keyNote { get; set; }
        public bool workshop { get; set; }
        public string sessionSequence { get; set; }
        public string sponsoredByName { get; set; }
        public string sponsoredByUrl { get; set; }
        public string sessionPrepMaterialsUrl { get; set; }
        public string speakersCombinedHtml { get; set; }
        public string topTag { get; set; }
        public string topTagSort { get; set; }
        public string satOrSun { get; set; }
        public string sessionSlug { get; set; }
        public string sessionUrl { get; set; }
        public string sessionUrlPre { get; set; }
        public int sessionTrackId { get; set; }
        public string descriptionEllipsized { get; set; }
        public int interestedCount { get; set; }
        public int notInterestedCount { get; set; }
        public int willAttendCount { get; set; }
        public bool interestedBool { get; set; }
        public bool notInterestedBool { get; set; }
        public int interestLevel { get; set; }
        public bool willAttendBool { get; set; }
        public string sessionLevel { get; set; }
        public int sessionLevelId { get; set; }
        public string presenterName { get; set; }
        public string presenterURL { get; set; }
        public string speakersShort { get; set; }
        public string speakersNamesCsv { get; set; }
        public string roomNumber { get; set; }
        public string roomNumberNew { get; set; }
        public string sessionTime { get; set; }
        public string startTime { get; set; }
        public DateTime sessionTimeDateTime { get; set; }
        public string titleWithPlanAttend { get; set; }
        public int notificationDestinationEmailCount { get; set; }
        public int notificationDestinationTextCount { get; set; }
        public string planAheadCount { get; set; }
        public int planAheadCountInt { get; set; }
        public string interestCount { get; set; }
        public int interestCountInt { get; set; }
        public string sessionPosted { get; set; }
        public bool loggedInUserInterested { get; set; }
        public bool loggedInUserPlanToAttend { get; set; }
        public int loggedInUserInterestLevelSort { get; set; }
        public string speakerPictureUrl { get; set; }
        public Tagsresult[] tagsResults { get; set; }
        public string tagsResultCsv { get; set; }
        public Speakerslist[] speakersList { get; set; }
        public string speakersCompaniesCsv { get; set; }
        public string titleEllipsized { get; set; }
        public bool saturdayOkForSession { get; set; }
        public bool sundayOkForSession { get; set; }
        public bool loggedInUserIsThisSpeaker { get; set; }
        public bool speakerWithMultipleSessions { get; set; }
        public string sessionTrackNameEllipsized { get; set; }
        public string descriptionFirstParagraph { get; set; }
        public string descriptionAfterFirstParagraph { get; set; }
        public int daysUntilNextPrice { get; set; }
        public int currentAttendance { get; set; }
        public int signupsUntilNextPrice { get; set; }
        public bool hasProctors { get; set; }
        public int sessionCapacityPercentRemaining { get; set; }
        public bool allowCheckAttend { get; set; }
        public float commissionAmount { get; set; }
        public int id { get; set; }
        public DateTime sessionStartDate { get; set; }
        public DateTime sessionEndDate { get; set; }
    }
}
