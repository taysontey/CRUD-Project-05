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
    [RoutePrefix("services/jogador")]
    public class JogadorController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Cadastrar(JogadorModelCadastro model)
        {
            try
            {
                Jogador j = new Jogador();
                j.Nome = model.Nome;
                j.Apelido = model.Apelido;
                j.DataNascimento = model.DataNascimento;
                j.Posicao = model.Posicao;
                j.IdTime = model.IdTime;

                JogadorDal d = new JogadorDal();
                d.Insert(j);

                return Request.CreateResponse(HttpStatusCode.OK, "Jogador cadastrado.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, e.Message);
            }
        }

        [HttpGet]
        [Route("consultar")]
        public List<JogadorModelConsulta> Consultar()
        {
            try
            {
                List<JogadorModelConsulta> lista = new List<JogadorModelConsulta>();

                JogadorDal d = new JogadorDal();

                foreach(Jogador j in d.FindAll())
                {
                    JogadorModelConsulta model = new JogadorModelConsulta();
                    model.IdJogador = j.IdJogador;
                    model.Nome = j.Nome;
                    model.Apelido = j.Apelido;
                    model.DataNascimento = j.DataNascimento.ToString("dd/MM/yyyy");
                    model.Posicao = j.Posicao;
                    model.Time = j.Time.Nome;

                    lista.Add(model);
                }

                return lista;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }
    }
}
