namespace Sln.Scheduler.Data.Enums;


public enum JobTypeEnum
{
    SendMail = 0,
    SendSms = 1,
    SendNotification = 2,
    CampaignSchedule = 3,
    BirthDayAutomation = 4,
}

public enum JobStatus
{
    Pending = 0,
    Processing = 1,
    Completed = 2,
    Failed = 3,
    Deleted = 4
}


