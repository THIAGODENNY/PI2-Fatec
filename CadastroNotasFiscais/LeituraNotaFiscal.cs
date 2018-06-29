using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoAWS
{
    class LeituraNotaFiscal
    {
        private String nrNota;
        private String empresa;
        private String remetente;
        private String destinatario;
        
        

        public string NrNota { get => nrNota; set => nrNota = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public string Remetente { get => remetente; set => remetente = value; }
        public string Destinatario { get => destinatario; set => destinatario = value; }

        public String LeituraArquivoXML(String caminho, String inicial , String final, int tamanhoFixo, bool fimArquivo)
        {
            string inicioLeitura = inicial;
            string fimLeitura = final;

            string text;

            try
            {
                text = System.IO.File.ReadAllText(caminho);
            }

            catch
            {
                return "Erro Leitura Arquivo";
            }

            int start;
            if (fimArquivo == false)
            {
                start = text.IndexOf(inicial) + inicial.Length;
            }

            else
            {
                start = text.LastIndexOf(inicial) + inicial.Length;
            }

            int end;

            if(tamanhoFixo == 0)
            {
                if(fimArquivo == false)
                {
                    end = text.IndexOf(fimLeitura);
                }

                else
                {
                    end = text.LastIndexOf(fimLeitura);
                }
               
            }

            else
            {
                end = start + tamanhoFixo;
            }

            return text.Substring(start, end - start);
        }

        public String LeituraNrNota(String caminho)
        {
            return LeituraArquivoXML(caminho, "Id=\"NFe", "><ide><cUF>", 44, false);
        }

        public String LeituraNomeDestinatario(String caminho)
        {
            return LeituraArquivoXML(caminho, "</CNPJ><xNome>", "</xNome><enderDest><xLgr>", 0, true);
        }

        public String LeituraCidadeRemetente(String caminho)
        {
            return LeituraArquivoXML(caminho, "</cMun><xMun>", "</xMun>", 0, false);
        }

        public String LeituraCidadeDestinatario(String caminho)
        {
            return LeituraArquivoXML(caminho, "</cMun><xMun>", "</xMun>", 0, true);
        }

        public String LeituraEnderecoRemetente(String caminho)
        {
            String rua = LeituraArquivoXML(caminho, "</xFant><enderEmit><xLgr>", "</xLgr><nro>", 0, false);
            String numero = LeituraArquivoXML(caminho, "</xLgr><nro>", "</nro><xBairro>", 0, false);
            String cep = LeituraArquivoXML(caminho, "</UF><CEP>", "</CEP><cPais>", 0, false);
            return rua + " , "+numero+" , "+"CEP: " + cep;
        }

        public String LeituraEnderecoDestinatario(String caminho)
        {
            String rua = LeituraArquivoXML(caminho, "</xNome><enderDest><xLgr>", "</xLgr><nro>", 0, true);
            String numero = LeituraArquivoXML(caminho, "</xLgr><nro>", "</nro><xBairro>", 0, true);
            String cep = LeituraArquivoXML(caminho, "</UF><CEP>", "</CEP><cPais>", 0, true);
            String estado = LeituraArquivoXML(caminho, "</xMun><UF>", "</UF><CEP>", 0, true);
            return numero + "," + rua + "," + this.LeituraCidadeDestinatario(caminho) + "," + estado; 
        }
    }
}
