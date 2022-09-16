using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using moduloAPI2.Classes;

namespace moduloAPI2.ContextManagement{
    public class AgendaDB : DbContext{

        public DbSet<Contatos> Contatos {get; set;}
        //Vai virar uma tabela no meu banco de dados
        public AgendaDB(DbContextOptions<AgendaDB> options) : base(options){
            
        }
    }
}