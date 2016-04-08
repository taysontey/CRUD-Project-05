using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Web.Models;
using Projeto.Entity.Entities;
using Projeto.DAL.Persistence;

namespace Projeto.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("services/time")]
    public class TimeController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Cadastrar(TimeModelCadastro model)
        {
            try
            {
                Time t = new Time();
                t.Nome = model.Nome;
                t.DataFundacao = model.DataFundacao;

                TimeDal d = new TimeDal();
                d.Insert(t);

                return Request.CreateResponse(HttpStatusCode.OK, "Time cadastrado.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar")]
        public List<TimeModelConsulta> Consultar()
        {
            try
            {
                List<TimeModelConsulta> lista = new List<TimeModelConsulta>();
                TimeDal d = new TimeDal();

                foreach(Time t in d.FindAll())
                {
                    TimeModelConsulta model = new TimeModelConsulta();
                    model.IdTime = t.IdTime;
                    model.Nome = t.Nome;
                    model.DataFundacao = t.DataFundacao.ToString("dd/MM/yyyy");

                    lista.Add(model);
                }

                return lista;

            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        [HttpGet]
        [Route("editar")]
        public TimeModelConsulta Editar(int id)
        {
            try
            {
                TimeDal d = new TimeDal();
                Time t = d.FindById(id);

                TimeModelConsulta model = new TimeModelConsulta();
                model.IdTime = t.IdTime;
                model.Nome = t.Nome;
                model.DataFundacao = t.DataFundacao.ToString("dd/MM/yyyy");

                return model;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Atualizar(TimeModelEdicao model)
        {
            try
            {
                Time t = new Time();
                t.IdTime = model.IdTime;
                t.Nome = model.Nome;
                t.DataFundacao = model.DataFundacao;

                TimeDal d = new TimeDal();
                d.Update(t);

                return Request.CreateResponse(HttpStatusCode.OK, "Time atualizado.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, e.Message);
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                TimeDal d = new TimeDal();
                Time t = d.FindById(id);

                d.Delete(t);

                return Request.CreateResponse(HttpStatusCode.OK, "Time excluído.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, e.Message);
            }
        }
    }
}
