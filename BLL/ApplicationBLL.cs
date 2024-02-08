using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DAL;

namespace BLL
{
    public class ApplicationBLL
    {
        public List<ApplicationBO> GetApplications()
        {
            try
            {

                return new DAL.ApplicationDAL().GetApplication();
            }
            catch (Exception ex)
            {
                //ErrorLog error = new ErrorLog(ex, sessionID, null);
                //new LogsBLL().LogAnError(error);
                return null;
            }
        }

        public List<ApplicationStatusBO> GetApplicationsStatus()
        {
            try
            {

                return new DAL.ApplicationDAL().GetApplicationStatus();
            }
            catch (Exception ex)
            {
                //ErrorLog error = new ErrorLog(ex, sessionID, null);
                //new LogsBLL().LogAnError(error);
                return null;
            }
        }
        public List<ApplicaitonTypes> GetApplicationTypes()
        {
            try
            {
                return new DAL.ApplicationDAL().GetApplicationTypes();
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public List<Criticalitytype> GetCriticalityTypes()
        {
            try
            {
                return new DAL.ApplicationDAL().GetCriticalityTypes();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Servers> GetServers()
        {
            try
            {
                return new DAL.ApplicationDAL().GetServers();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateApplication(ApplicationBO Application)
        {
            try
            {
                
                new DAL.ApplicationDAL().UpdateApplication(Application);
                return true;
            }
            catch (Exception ex)
            {
                //ErrorLog error = new ErrorLog(ex, Application.SessionID, null);
                //new LogsBLL().LogAnError(error);
                return false;
            }
        }



        public bool InsertApplication(ApplicationBO Application)
        {
            try
            {
                new DAL.ApplicationDAL().InsertApplication(Application);
                return true;
            }
            catch (Exception ex)
            {
                //ErrorLog error = new ErrorLog(ex, Application.SessionID, null);
                //new LogsBLL().LogAnError(error);
                return false;
            }
        }
        


    }
}
