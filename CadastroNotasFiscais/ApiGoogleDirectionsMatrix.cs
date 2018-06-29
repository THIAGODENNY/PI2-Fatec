using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Net;

namespace ConexaoAWS
{
    class ApiGoogleDirectionsMatrix
    {
        public String conversaoListaStringEnderecos(List<String> ListaEnderecos)
        {
            String ListaStringEnderecos = "|";

            for (int i = 0; i < ListaEnderecos.Count(); i++)
            {
                ListaStringEnderecos = ListaStringEnderecos + ListaEnderecos[i] + "|";
            }
            return ListaStringEnderecos;
        }

        public String criaOrigem()
        {
            return "65,Rua Dom Pedro I,Indaiatuba,SP";
        }

        public String criaKey()
        {
            return "";
        }

        public List<String> apiTracaRota(String origem, String destinos, String key)
        {
            var url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origem + "&destination=" + origem + "&waypoints=optimize:true" + destinos + "&key=" + key;
            var client = new WebClient();
            var content = client.DownloadString(url);

            Console.WriteLine(url);

            string inicioLeitura = "waypoint_order";
            string fimLeitura = "]\n";

            int start;

            start = content.IndexOf(inicioLeitura) + inicioLeitura.Length+6;

            int end;
            end = content.LastIndexOf(fimLeitura);

            String rotaSequenciaAux = "";
            List<String> rotaTracada = new List<string>();

            try
            {
                 rotaSequenciaAux = content.Substring(start, end - start);
            }

            catch
            {
                Console.WriteLine("Nenhuma Ordem Encontrada!");
                return rotaTracada;
            }

            String rotaSequencia = rotaSequenciaAux;

            IList<String> rota = rotaSequencia.Split(',').ToList<String>();
            IList<String> sequenciaEnderecos = destinos.Split('|').ToList<String>();

            

            for (int i = 0; i < rota.Count(); i++)
            {
                int index = Convert.ToInt32(rota[i]);
                index++;
                rotaTracada.Insert(i, sequenciaEnderecos[index]);
            }

            return rotaTracada;
        }


        public List<String> getRotaFuncionario(String idFuncionario)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            IEnumerable<Servicos> rotaOrdemServico = ComandoAWS.SearchDataTabelaServicos(context, "", idFuncionario, "", "", "", "");
            List<Servicos> rotaOrdemServicoList = rotaOrdemServico.ToList();

            List<String> rota = new List<string>();

            int j = 0;

            for (int i = 0; i < rotaOrdemServicoList.Count(); i++)
            {
                if (rotaOrdemServicoList[i].status == "aguardando retirada")
                {
                    String conversaoEnderecoRota = Convert.ToString(rotaOrdemServicoList[i].enderecoDestinatario);
                    rota.Insert(j,conversaoEnderecoRota);
                    j++;

                    Console.WriteLine("teste:"+rota);
                }              
            }
            return this.apiTracaRota(criaOrigem(), this.conversaoListaStringEnderecos(rota), criaKey());            

        }
    }
}
