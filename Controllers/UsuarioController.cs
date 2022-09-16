using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace moduloAPI2.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase{
        
        [HttpGet]
        public object GetDataHora(){

            var obj = new {
                data = DateTime.Now.ToLongDateString(),
                hora = DateTime.Now.ToShortTimeString()
            };
            return obj;
        }
    }
}