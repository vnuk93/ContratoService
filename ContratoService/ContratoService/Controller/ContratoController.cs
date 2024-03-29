﻿using Grapevine.Interfaces.Server;
using Grapevine.Server;
using Grapevine.Server.Attributes;
using Grapevine.Shared;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoService
{
    [RestResource]
    class ContratoController
    {
        MainCore _ = new MainCore("mongodb://51.83.73.69:27017", "ContratoService");

        #region GET
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/api/contrato/all")]
        public IHttpContext ReadAllContacto(IHttpContext context)
        {

            var data = _.ReadAll();

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            context.Response.AppendHeader("Content-Type", "application/json");
            context.Response.SendResponse(json);
            return context;
        }

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/api/contrato/one")]
        public IHttpContext ReadOneContacto(IHttpContext context)
        {

            var id = context.Request.QueryString["id"] ?? "what?"; //Si no id dara error
            var data = _.ReadId(id);

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            context.Response.AppendHeader("Content-Type", "application/json");
            context.Response.SendResponse(json);
            return context;
        }
        #endregion

        #region POST

        [RestRoute(HttpMethod = HttpMethod.POST, PathInfo = "/api/ticket/add")]
        public IHttpContext AddContacto(IHttpContext context)
        {

            string jsonRAW = context.Request.Payload;
            dynamic dataId = JsonConvert.DeserializeObject<object>(jsonRAW);

            MContrato data = new MContrato();

            

            //data.fecha = DateTime.Now;
            //data.visible = dataId?.visible == "true" ? true : false;
            ////DANGER

            //data.employeeServiceID = new Regex(@"^[0-9a-fA-F]{24}$").Match(dataId?.employeeServiceID.ToString()).Success == true ? ObjectId.Parse(dataId?.employeeServiceID.ToString()) : null;
            //data.documentServiceID = new Regex(@"^[0-9a-fA-F]{24}$").Match(dataId?.documentServiceID.ToString()).Success == true ? ObjectId.Parse(dataId?.documentServiceID.ToString()) : null;
            //data.mensaje = dataId?.mensaje;
            //data.serviceID = new Regex(@"^[0-9a-fA-F]{24}$").Match(dataId?.serviceID.ToString()).Success == true ? ObjectId.Parse(dataId?.serviceID.ToString()) : null;
            //data.tipoServicio = dataId?.tipoServicio;

            _.Create(data);

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            context.Response.AppendHeader("Content-Type", "application/json");
            context.Response.SendResponse(json);
            return context;
        }

        #endregion

        #region PUT

        [RestRoute(HttpMethod = HttpMethod.PUT, PathInfo = "/api/ticket/update")]
        public IHttpContext UpdateContacto(IHttpContext context)
        {

            string jsonRAW = context.Request.Payload;
            var id = context.Request.QueryString["id"] ?? "what?";

            dynamic dataId = JsonConvert.DeserializeObject<object>(jsonRAW);

            MContrato data = new MContrato();

            //data.fecha = DateTime.Now; La fecha no se puede actualizar y la id de abajo la tiene qe ver para insertarla despues.

            //data._id = ObjectId.Parse(id);
            //data.visible = dataId?.visible == "true" ? true : false;

            //data.employeeServiceID = new Regex(@"^[0-9a-fA-F]{24}$").Match(dataId?.employeeServiceID.ToString()).Success == true ? ObjectId.Parse(dataId?.employeeServiceID.ToString()) : null;
            //data.documentServiceID = new Regex(@"^[0-9a-fA-F]{24}$").Match(dataId?.documentServiceID.ToString()).Success == true ? ObjectId.Parse(dataId?.documentServiceID.ToString()) : null;
            //data.mensaje = dataId?.mensaje;
            //data.serviceID = new Regex(@"^[0-9a-fA-F]{24}$").Match(dataId?.serviceID.ToString()).Success == true ? ObjectId.Parse(dataId?.serviceID.ToString()) : null;
            //data.tipoServicio = dataId?.tipoServicio;

            //_.Update(id, data);

            context.Response.SendResponse("No esta permitido modificar un ticket!");
            return context;

        }


        #endregion

    }
}
