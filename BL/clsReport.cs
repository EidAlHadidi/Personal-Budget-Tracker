using System;
using System.Data;
using DAL;
namespace BL
{

    public class clsReport
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ReportID { get; set; }
        public int UserID { get; set; }
        public int ReportTypeID { get; set; }
        public string ReportData { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string Description { get; set; }


        public clsReport()
        {
            this.ReportID = default;
            this.UserID = default;
            this.ReportTypeID = default;
            this.ReportData = default;
            this.GeneratedAt = default;
            this.Description = default;


            Mode = enMode.AddNew;

        }

        private clsReport(int ReportID, int UserID, int ReportTypeID, string ReportData, DateTime GeneratedAt, string Description)
        {
            this.ReportID = ReportID;
            this.UserID = UserID;
            this.ReportTypeID = ReportTypeID;
            this.ReportData = ReportData;
            this.GeneratedAt = GeneratedAt;
            this.Description = Description;


            Mode = enMode.Update;

        }

        private bool _AddNewReport()
        {
            //call DataAccess Layer 

            this.ReportID = DAL_Reports.AddNewReport(this.UserID, this.ReportTypeID, this.ReportData, this.GeneratedAt, this.Description);

            return (this.ReportID != -1);

        }

        private bool _UpdateReport()
        {
            //call DataAccess Layer 

            return DAL_Reports.UpdateReport(this.ReportID, this.UserID, this.ReportTypeID, this.ReportData, this.GeneratedAt, this.Description);

        }

        public static clsReport Find(int ReportID)
        {
            int UserID = default;
            int ReportTypeID = default;
            string ReportData = default;
            DateTime GeneratedAt = default;
            string Description = default;


            if (DAL_Reports.GetReportInfoByID(ReportID, ref UserID, ref ReportTypeID, ref ReportData, ref GeneratedAt, ref Description))
                return new clsReport(ReportID, UserID, ReportTypeID, ReportData, GeneratedAt, Description);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReport())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateReport();

            }




            return false;
        }

        public static DataTable GetAllReports() { return DAL_Reports.GetAllReports(); }

        public static bool DeleteReport(int ReportID) { return DAL_Reports.DeleteReport(ReportID); }

        public static bool isReportExist(int ReportID) { return DAL_Reports.IsReportExist(ReportID); }


    }

}