using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;

namespace MVCLaboratorio.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            //Mostrar Datos
            ViewData["video"] = BaseHelper.ejecutarConsulta("SP_video_MOSTRAR", CommandType.StoredProcedure);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int idVideo, string titulo, int repro, string url)
        {
            //Guardar los datos
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@repro", repro));
            parametros.Add(new SqlParameter("@url", url));

            BaseHelper.ejecutarSentencia("SP_VIDEO_INSERT", CommandType.StoredProcedure, parametros);
            return RedirectToAction("Index", "Video");
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string titulo, int repro, string url, int idVideo)
        {
            //Actualizar Datos
            string sentencia = "SP_video_ACTUALIZAR";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@repro", repro));
            parametros.Add(new SqlParameter("@url", url));
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            BaseHelper.ejecutarSentencia(sentencia, CommandType.StoredProcedure, parametros);
            return RedirectToAction("Index", "Video");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int idVideo)
        {
            //Eliminar registro
            string sentencia = "SP_video_ELIMINAR";
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            BaseHelper.ejecutarSentencia(sentencia, CommandType.StoredProcedure, parametros);
            return RedirectToAction("Index", "Video");
        }


    }
}
