using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moduloAPI2.ContextManagement;
using moduloAPI2.Classes;
using Microsoft.EntityFrameworkCore;

namespace moduloAPI2.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class ContatosController : ControllerBase{
        
        private readonly AgendaDB _instance;
        public ContatosController(AgendaDB instance){
            this._instance = instance;
        }

        [HttpGet]
        public List<Contatos> GetContatos(){

            if(_instance.Contatos != null)
                return _instance.Contatos.ToList();
            else
                throw new NullReferenceException("Contato does not exist!");
        }

        [HttpGet("{id}")]
        public Contatos GetById(int id){

            if(_instance.Contatos != null)
                return _instance.Contatos.Find(id);
            else
                throw new NullReferenceException("Contato does not exist!");
        }

        [HttpPost]
        public IActionResult InsertInto(Contatos contato){

            _instance.Add(contato);
            _instance.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = contato.id}, contato);
        }

        [HttpPut("{id}")]
        public Contatos UpdateContato(int id, Contatos contato){

            var contatoBanco = _instance.Contatos.Find(id);

            if(contatoBanco == null)
                throw new NullReferenceException("Contato does not exist!");
            else
                contatoBanco.nome = contato.nome;
                contatoBanco.telefone = contato.telefone;
                contatoBanco.ativo = contato.ativo;

                _instance.Contatos.Update(contatoBanco);
                _instance.SaveChanges();

                return contatoBanco;
        }

        [HttpDelete("{id}")]
        public object DeleteContato(int id){
            
            var contatoBanco = _instance.Contatos.Find(id);
            var obj = new {
                mensagem = "Contato deletado com sucesso!"
            };

            if(contatoBanco == null)
                throw new NullReferenceException("Contato already does not exist!");
            else
                _instance.Contatos.Remove(contatoBanco);
                _instance.SaveChanges();

            return obj;
        }
    }
}