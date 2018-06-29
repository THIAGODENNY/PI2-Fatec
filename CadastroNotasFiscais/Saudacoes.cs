using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoAWS
{
    class Saudacoes
    {
        public String BomDia()
        {
            int hora = DateTime.Now.Hour;

           if(hora >= 6 && hora < 12)
            {
                return "Bom dia!";
            }

            else if(hora >=12 && hora < 18)
            {
                return "Boa Tarde";
            }

            else
            {
                return "Boa noite!";
            }          
        }
    }
}
