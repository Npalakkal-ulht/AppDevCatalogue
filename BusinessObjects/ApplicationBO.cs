using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ApplicationBO
    {

        public byte ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public byte AppTypeID { get; set; }
        public string AppTypeName { get; set; }
        public Nullable<byte> CriticalityID { get; set; }
        public string CriticalityName { get; set; }
        public string ApplicationDescription { get; set; }
        public Nullable<byte> AppServerID { get; set; }
        public string APPServerName { get; set; }
        public Nullable<byte> DBServerID { get; set; }
        public string DBServerName { get; set; }
        public string DBName { get; set; }
        public string AppURL { get; set; }
        public bool ADLinked { get; set; }
        public Nullable<byte> NotesID { get; set; }
        public string ApplicationNotesText { get; set; }
        public byte AppStatusID { get; set; }
        public string StatusName { get; set; }
        public System.DateTime DateCreated { get; set; }
        public byte CreatedByUserID { get; set; }
        public Nullable<System.DateTime> DateLastEdited { get; set; }
        public Nullable<byte> EditedByUserID { get; set; }
        public bool IsActive { get; set; }

        //public virtual ApplicationNote ApplicationNote { get; set; }
        //public virtual Server Server { get; set; }
        //public virtual ApplicationStatus ApplicationStatus { get; set; }
        //public virtual AppType AppType { get; set; }
        //public virtual Criticality Criticality { get; set; }
        //public virtual Server Server1 { get; set; }

    }

    public class ApplicaitonTypes
    {
        public byte AppTypeID { get; set; }
        public string AppTypeName { get; set; }
        public bool IsActive { get; set; }

    }

    public class Criticalitytype
    {
        public byte CriticalityID { get; set; }
        public string CriticalityName { get; set; }
        public bool IsActive { get; set; }

    }

    public class Servers
    {
        public byte ServerID { get; set; }
        public string ServerName { get; set; }
        public bool IsActive { get; set; }

    }

    public class Notes
    {
        public byte ApplicationNotesID { get; set; }
        public string ApplicationNotesText { get; set; }
        public byte CreatedByUserID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateLastEdited { get; set; }
        public Nullable<byte> EditedByUserID { get; set; }
        public bool IsActive { get; set; }
    }

    public class ApplicationStatusBO
    {
        public byte StatusID { get; set; }
        public string StatusName { get; set; }
        public bool IsActive { get; set; }
    }
}
