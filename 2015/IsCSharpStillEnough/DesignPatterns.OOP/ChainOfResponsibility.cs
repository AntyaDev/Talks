using System;

namespace DesignPatterns.OOP
{
    class LeaveSettings
    {
        public LeaveSettings(string userId, int numberOfDays)
        {
            UserId = userId;
            NumberOfDays = numberOfDays;
        }

        public string UserId { get; private set; }
        public int NumberOfDays { get; private set; }
    }

    abstract class LeaveHandler
    {
        protected LeaveHandler NextLeaveHandler;

        public abstract void ProcessLeave(LeaveSettings leaveSettings);

        public void SetNextLeaveHandler(LeaveHandler nextHandler)
        {
            NextLeaveHandler = nextHandler;
        }
    }

    class ReportingManager : LeaveHandler
    {
        public override void ProcessLeave(LeaveSettings leaveSettings)
        {
            if (leaveSettings.NumberOfDays < 3)
            {
                Console.WriteLine("Leave applied for {0}, on {1} days by ReportingManager",
                    leaveSettings.UserId, leaveSettings.NumberOfDays);
            }
            else NextLeaveHandler.ProcessLeave(leaveSettings);
        }
    }

    class ProjectManager : LeaveHandler
    {
        public override void ProcessLeave(LeaveSettings leaveSettings)
        {
            if (leaveSettings.NumberOfDays > 3 && leaveSettings.NumberOfDays <= 10)
            {
                Console.WriteLine("Leave applied for {0}, on {1} days by ProjectManager",
                    leaveSettings.UserId, leaveSettings.NumberOfDays);
            }
            else NextLeaveHandler.ProcessLeave(leaveSettings);
        }
    }

    class Managment : LeaveHandler
    {
        public override void ProcessLeave(LeaveSettings leaveSettings)
        {
            Console.WriteLine("Leave applied for {0}, on {1} days by Managment",
                leaveSettings.UserId, leaveSettings.NumberOfDays);
        }
    }

    class ChainOfResponsibilityDemo
    {
        public void Demo()
        {
            var reportManger = new ReportingManager();
            var projectManager = new ProjectManager();
            var managment = new Managment();

            reportManger.SetNextLeaveHandler(projectManager);
            projectManager.SetNextLeaveHandler(managment);

            reportManger.ProcessLeave(new LeaveSettings("Test User Id", 2));
            reportManger.ProcessLeave(new LeaveSettings("Test User Id", 5));
            reportManger.ProcessLeave(new LeaveSettings("Test User Id", 15));
        }
    }
}
