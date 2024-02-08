using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BusinessObjects;

namespace DAL
{
    public class ApplicationDAL
    {


        //public List<ApplicationBO> GetApplications()
        //{
        //    using (var ctx = new Model.AppDevCatalogueEntities())
        //    {
        //        return ctx.Applications.Where(x => x.IsActive).Select(x => new ApplicationBO
        //        {
        //            ApplicationID = x.ApplicationID,
        //            ApplicationName = x.ApplicationName,
        //            AppTypeID = x.AppTypeID,
        //            CriticalityID = x.CriticalityID,
        //            ApplicationDescription = x.ApplicationDescription,
        //            AppServerID = x.AppServerID,
        //            DBServerID = x.DBServerID,
        //            DBName = x.DBName,
        //            AppURL = x.AppURL,
        //            ADLinked = x.ADLinked,
        //            NotesID = x.NotesID,
        //            AppStatusID = x.AppStatusID,
        //            DateCreated = x.DateCreated,
        //            CreatedByUserID = x.CreatedByUserID,
        //            DateLastEdited = x.DateLastEdited,
        //            EditedByUserID = x.EditedByUserID,
        //            IsActive = x.IsActive

        //        }).ToList();
        //    }

        //}
        public List<ApplicationBO> GetApplication()
        {
            using (var ctx = new Model.AppDevCatalogueEntities())
            {
                //return ctx.Applications.Where(x => x.IsActive).Select(x => new ApplicationBO
                return (from dt in ctx.Applications
                        join m in ctx.AppTypes on dt.AppTypeID equals m.AppTypeID
                        join n in ctx.Servers on dt.AppServerID equals n.ServerID into AppSer
                                from appser in AppSer.DefaultIfEmpty()
                        join o in ctx.Servers on dt.AppServerID equals o.ServerID into DBSer
                        from dbser in DBSer.DefaultIfEmpty()
                        join p in ctx.Criticalities on dt.CriticalityID equals p.CriticalityID
                        join r in ctx.ApplicationStatuses on dt.AppStatusID equals r.StatusID
                        join q in ctx.ApplicationNotes on dt.NotesID equals q.ApplicationNotesID into PS
                        from ps in PS.DefaultIfEmpty()
                            where dt.IsActive == true
                        select new ApplicationBO
                        {
                            ApplicationID = dt.ApplicationID,
                            ApplicationName = dt.ApplicationName,
                            AppTypeID = m.AppTypeID,
                            AppTypeName = m.AppTypeName,
                            CriticalityID = dt.CriticalityID,
                            CriticalityName = p.CriticalityName,
                            ApplicationDescription = dt.ApplicationDescription,
                            AppServerID = dt.AppServerID,
                            APPServerName = appser.ServerName,
                            DBServerID = dt.DBServerID,
                            DBServerName = dbser.ServerName,
                            DBName = dt.DBName,
                            AppURL = dt.AppURL,
                            ADLinked = dt.ADLinked,
                            NotesID = dt.NotesID,
                            ApplicationNotesText = ps.ApplicationNotesText,
                            AppStatusID = dt.AppStatusID,
                            StatusName = r.StatusName,
                            DateCreated = dt.DateCreated,
                            CreatedByUserID = dt.CreatedByUserID,
                            DateLastEdited = dt.DateLastEdited,
                            EditedByUserID = dt.EditedByUserID,
                            IsActive = dt.IsActive
                        }).ToList();
            }
        }

        public List<ApplicaitonTypes> GetApplicationTypes()
        {
            using (var ctx = new Model.AppDevCatalogueEntities())
            {
                return ctx.AppTypes.Where(x => x.IsActive).Select(x => new ApplicaitonTypes
                {
                    AppTypeID = x.AppTypeID,
                    AppTypeName = x.AppTypeName
                }).ToList();

            }
        }

        public List<ApplicationStatusBO> GetApplicationStatus()
        {
            using (var ctx = new Model.AppDevCatalogueEntities())
            {
                return ctx.ApplicationStatuses.Where(x => x.IsActive).Select(x => new ApplicationStatusBO
                {
                    StatusID = x.StatusID,
                    StatusName = x.StatusName

                }).ToList();

            }
        }
        public List<Criticalitytype> GetCriticalityTypes()
        {
            using (var ctx = new Model.AppDevCatalogueEntities())
            {
                return ctx.Criticalities.Where(x => x.IsActive).Select(x => new Criticalitytype
                {
                    CriticalityID = x.CriticalityID,
                    CriticalityName = x.CriticalityName

                }).ToList();

            }
        }
        public List<Servers> GetServers()
        {
            using (var ctx = new Model.AppDevCatalogueEntities())
            {
                return ctx.Servers.Where(x => x.IsActive).Select(x => new Servers
                {
                    ServerID = x.ServerID,
                    ServerName = x.ServerName

                }).ToList();

            }
        }

        public void InsertDeviceType(ApplicationBO d)
        {


        }
        public void UpdateApplication(ApplicationBO d)
        {
            using (var ctx = new Model.AppDevCatalogueEntities())
            {
                using (var dbContextTransaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (d.NotesID != null)
                        {
                            List<BusinessObjects.Notes> notes = new List<BusinessObjects.Notes>();
                            var device1 = ctx.ApplicationNotes.Where(x => x.ApplicationNotesID == d.NotesID).Single();
                            device1.ApplicationNotesText = d.ApplicationNotesText;
                            device1.EditedByUserID = d.EditedByUserID;
                            device1.DateLastEdited = d.DateLastEdited;
                            ctx.SaveChanges();
                            //dbContextTransaction.Commit();
                        }
                        else
                        {
                            Model.ApplicationNote dt = new Model.ApplicationNote()
                            {
                                ApplicationNotesText = d.ApplicationNotesText,
                                CreatedByUserID = d.CreatedByUserID,
                                DateCreated = DateTime.Now,
                                EditedByUserID = d.EditedByUserID,
                                IsActive = true,
                            };

                            ctx.ApplicationNotes.Add(dt);
                            ctx.SaveChanges();
                            //dbContextTransaction.Commit();
                            d.NotesID = dt.ApplicationNotesID;
                        }

                        List<BusinessObjects.ApplicationBO> detail = new List<BusinessObjects.ApplicationBO>();
                        var device = ctx.Applications.Where(x => x.ApplicationID == d.ApplicationID).Single();
                        device.ApplicationName = d.ApplicationName;
                        device.AppTypeID = d.AppTypeID;
                        device.CriticalityID = d.CriticalityID;
                        device.ApplicationDescription = d.ApplicationDescription;
                        device.AppServerID = d.AppServerID;
                        device.DBServerID = d.DBServerID;
                        device.DBName = d.DBName;
                        device.AppURL = d.AppURL;
                        device.ADLinked = d.ADLinked;
                        device.NotesID = d.NotesID;
                        device.AppStatusID = d.AppStatusID;
                        //device.DateCreated = d.DateCreated;
                        device.EditedByUserID = d.EditedByUserID;
                        device.IsActive = d.IsActive;
                        ctx.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        public void InsertApplication(ApplicationBO d)
        {
            using (var ctxIns = new Model.AppDevCatalogueEntities())
            {
                using (var dbContextTransactionIns = ctxIns.Database.BeginTransaction())
                {
                    try
                    {
                        if (d.NotesID == null)
                        {
                            if (d.ApplicationNotesText != null)
                            {
                                Model.ApplicationNote dt = new Model.ApplicationNote()
                                {

                                    ApplicationNotesText = d.ApplicationNotesText,
                                    CreatedByUserID = d.CreatedByUserID,
                                    DateCreated = d.DateCreated,
                                    DateLastEdited = d.DateLastEdited,
                                    EditedByUserID = d.EditedByUserID,
                                    IsActive = true

                                };
                                ctxIns.ApplicationNotes.Add(dt);
                                ctxIns.SaveChanges();
                                d.NotesID = dt.ApplicationNotesID;
                            }
                        }
                        //Model.AppType dt = new Model.AppType()
                        //{
                        //    AppTypeName = d.AppTypeName,
                        //    IsActive = d.IsActive
                        //};
                        //ctx.AppTypes.Add(dt);
                        //ctx.SaveChanges();
                        //int AppTypeID = dt.AppTypeID;

                        //Model.Criticality dt1 = new Model.Criticality()
                        //{
                        //    CriticalityName = d.CriticalityName,
                        //    IsActive = d.IsActive
                        //};
                        //ctx.Criticalities.Add(dt1);
                        //ctx.SaveChanges();
                        //int CritID = dt1.CriticalityID;


                        Model.Application dt2 = new Model.Application()
                        {
                            ApplicationName = d.ApplicationName,
                            AppTypeID = d.AppTypeID,
                            CriticalityID = d.CriticalityID,
                            ApplicationDescription = d.ApplicationDescription.Trim(),
                            AppServerID = d.AppServerID,
                            DBServerID = d.DBServerID,
                            DBName = d.DBName,
                            AppURL = d.AppURL,
                            ADLinked = d.ADLinked,
                            NotesID = d.NotesID,
                            AppStatusID = d.AppStatusID,
                            CreatedByUserID = d.CreatedByUserID,
                            DateCreated = d.DateCreated,
                            IsActive = true

                        };

                        ctxIns.Applications.Add(dt2);
                        ctxIns.SaveChanges();

                        //new LogsDAL().LogUserAudit(new BusinessObjects.LogAudit()
                        //{
                        //    LogSenderActionID = BusinessObjects.LogSenderAction.CreateDeviceType,
                        //    LogCrudActionID = LogCRUDAction.Create,
                        //    LogRecordID = dt.DeviceTypeID,
                        //    LogActionDateTime = System.DateTime.Now,
                        //    LogTableID = BusinessObjects.LogTable.DeviceType,
                        //    LogSessionID = d.SessionID
                        //}, ctx);

                        dbContextTransactionIns.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransactionIns.Rollback();
                    }
                }
            }
        }

        //public void InsertDeviceType(DeviceType d)
        //{
        //    using (var ctx = new MODEL.MDMEntities())
        //    {
        //        using (var dbContextTransaction = ctx.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                MODEL.DeviceType dt = new MODEL.DeviceType()
        //                {
        //                    IsActive = d.IsActive,
        //                    DeviceCategoryID = d.CategoryID,
        //                    DeviceMakeID = d.MakeID,
        //                    DeviceModel = d.Model.Trim(),
        //                    RequiresIMEI = d.RequiresIMEINumber,
        //                    RequiresITNumber = d.RequiresITNumber,
        //                    RequiresSerialNumber = d.RequiresSerialNumber
        //                };

        //                ctx.DeviceTypes.Add(dt);
        //                ctx.SaveChanges();

        //                new LogsDAL().LogUserAudit(new BusinessObjects.LogAudit()
        //                {
        //                    LogSenderActionID = BusinessObjects.LogSenderAction.CreateDeviceType,
        //                    LogCrudActionID = LogCRUDAction.Create,
        //                    LogRecordID = dt.DeviceTypeID,
        //                    LogActionDateTime = System.DateTime.Now,
        //                    LogTableID = BusinessObjects.LogTable.DeviceType,
        //                    LogSessionID = d.SessionID
        //                }, ctx);

        //                dbContextTransaction.Commit();
        //            }
        //            catch (Exception)
        //            {
        //                dbContextTransaction.Rollback();
        //            }
        //        }
        //    }
        //}

    }

}
