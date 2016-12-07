﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CloneDeploy_App.BLL;
using CloneDeploy_App.Controllers.Authorization;
using CloneDeploy_App.DTOs;
using CloneDeploy_Entities;
using CloneDeploy_Entities.DTOs;
using CloneDeploy_Services;


namespace CloneDeploy_App.Controllers
{
    public class SysprepTagController: ApiController
    {
        private readonly SysprepTagServices _sysprepTagServices;

        public SysprepTagController()
        {
            _sysprepTagServices = new SysprepTagServices();
        }

        [GlobalAuth(Permission = "GlobalRead")]
        public IEnumerable<SysprepTagEntity> GetAll(string searchstring = "")
        {
            return string.IsNullOrEmpty(searchstring)
                ? _sysprepTagServices.SearchSysprepTags()
                : _sysprepTagServices.SearchSysprepTags(searchstring);

        }

        [GlobalAuth(Permission = "GlobalRead")]
        public ApiStringResponseDTO GetCount()
        {
            return new ApiStringResponseDTO() {Value = _sysprepTagServices.TotalCount()};
        }

        [GlobalAuth(Permission = "GlobalRead")]
        public SysprepTagEntity Get(int id)
        {
            var result = _sysprepTagServices.GetSysprepTag(id);
            if (result == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            return result;
        }

        [GlobalAuth(Permission = "GlobalCreate")]
        public ActionResultDTO Post(SysprepTagEntity sysprepTag)
        {
            return _sysprepTagServices.AddSysprepTag(sysprepTag);
        }

        [GlobalAuth(Permission = "GlobalUpdate")]
        public ActionResultDTO Put(int id, SysprepTagEntity sysprepTag)
        {
            sysprepTag.Id = id;
            var result = _sysprepTagServices.UpdateSysprepTag(sysprepTag);
             if (result == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            return result;
        }

        [GlobalAuth(Permission = "GlobalDelete")]
        public ActionResultDTO Delete(int id)
        {
            var result = _sysprepTagServices.DeleteSysprepTag(id);
            if (result == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            return result;
        }
    }
}