﻿using System;
using System.Linq;
using CloneDeploy_DataModel;
using CloneDeploy_Entities;

namespace CloneDeploy_Services
{
    public class AuditLogServices
    {
        private readonly UnitOfWork _uow;

        public AuditLogServices()
        {
            _uow = new UnitOfWork();
        }

        public void AddAuditLog(AuditLogEntity auditLog)
        {
            _uow.AuditLogRepository.Insert(auditLog);
            _uow.Save();
        }

        public DateTime? GetImageLastUsedDate(int imageId)
        {
            var auditLog = _uow.AuditLogRepository.Get(
                x =>
                    x.ObjectType == "Image" && x.ObjectId == imageId &&
                    (x.AuditType.ToString().ToLower().Contains("deploy") || x.AuditType.ToString().ToLower().Contains("upload") || x.AuditType.ToString().ToLower().Contains("push") || x.AuditType.ToString().ToLower().Contains("multicast")))
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if (auditLog != null)
                return auditLog.DateTime;
            return null;
        }
    }
}