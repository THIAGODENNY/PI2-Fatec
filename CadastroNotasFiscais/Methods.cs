/*******************************************************************************
* Copyright 2009-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
* 
* Licensed under the Apache License, Version 2.0 (the "License"). You may
* not use this file except in compliance with the License. A copy of the
* License is located at
* 
* http://aws.amazon.com/apache2.0/
* 
* or in the "license" file accompanying this file. This file is
* distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
* KIND, either express or implied. See the License for the specific
* language governing permissions and limitations under the License.
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Net;
using Amazon.DynamoDBv2.DocumentModel;

namespace ConexaoAWS
{
    public partial class ComandoAWS
    {
        public static void AddEmployer(DynamoDBContext context, String id, String nome)
        {
            Console.WriteLine("Criando Funcionarios");
            Funcionarios funcionario = new Funcionarios
            {
                id = id.ToLower(),
                nome = nome.ToLower()
            };

            Console.WriteLine("Salvando Funcionario");
            context.Save<Funcionarios>(funcionario);
        }

        public static void DeleteEmployer(DynamoDBContext context, String id, String nome)
        {
            Console.WriteLine("Apagando Funcionario");
            Funcionarios funcionario = new Funcionarios
            {
                id = id.ToLower(),
                nome = nome.ToLower()
            };
            
            context.Delete<Funcionarios>(funcionario);
            Console.WriteLine("Funcionário Apagado");
        }

        public static void AddJob(DynamoDBContext context, String xml, String id, String nomeDestinatario, String enderecoDestinatario,String destinatario, String status)
        {
            Console.WriteLine("Criando Funcionarios");
            Servicos servicos = new Servicos
            {
                xml = xml.ToLower(),
                id = id.ToLower(),
                nomeDestinatario = nomeDestinatario.ToLower(),
                enderecoDestinatario = enderecoDestinatario.ToLower(),
                cidadeDestinatario = destinatario.ToLower(),
                status = status.ToLower(),
            };

            Console.WriteLine("Salvando Ordem de Servico");
            context.Save<Servicos>(servicos);
        }

        public static void deleteJob(DynamoDBContext context, String xml, String id, String nomeDestinatario, String enderecoDestinatario, String destinatario, String status)
        {
            Console.WriteLine("Deletando ordem de serviço");
            Servicos servicos = new Servicos
            {
                xml = xml.ToLower(),
                id = id.ToLower(),
                nomeDestinatario = nomeDestinatario.ToLower(),
                enderecoDestinatario = enderecoDestinatario.ToLower(),
                cidadeDestinatario = destinatario.ToLower(),
                status = status.ToLower(),
            };

            context.Delete<Servicos>(servicos);
        }

        public static void AddCity(DynamoDBContext context, String cidadeDestinatario, String id)
        {
            Console.WriteLine("Criando Cidades");
            Cidades cidades = new Cidades
            {
                cidadeDestinatario = cidadeDestinatario.ToLower(),
                id = id.ToLower(),
            };
            Console.WriteLine("Salvando Ordem de Servico");
            context.Save<Cidades>(cidades);
        }

        public static void DeleteCity(DynamoDBContext context, String cidadeDestinatario, String id)
        {
            Console.WriteLine("Criando Cidades");
            Cidades cidades = new Cidades
            {
                cidadeDestinatario = cidadeDestinatario.ToLower(),
                id = id.ToLower(),
            };
            Console.WriteLine("Salvando Ordem de Servico");
            context.Delete<Cidades>(cidades);
        }

        public static void AddUser(DynamoDBContext context, String user, String password)
        {
            Console.WriteLine("Criando Usuario");
            Login login = new Login
            {
                user = user.ToLower(),
                password = password,
            };
            Console.WriteLine("Salvando usuario");
            context.Save<Login>(login);
        }

        public static void DeleteUser(DynamoDBContext context, String user)
        {
            Console.WriteLine("Deletando Usuario");
            Login login = new Login
            {
                user = user.ToLower(),
            };

            if (user.ToLower() != "admin")
            {
                Console.WriteLine("Deletando usuario");
                context.Delete<Login>(login);
            }
            else
            {
                Console.WriteLine("Não é possível deletar o administrador do Sistema");
            }
        }

        public static String SearchFuncionarios(DynamoDBContext context,String coluna, String item, String Return)
        {
            String resultado = "";
            IEnumerable<Funcionarios> funcionariosScanResults;
            Console.WriteLine();
            funcionariosScanResults = context.Scan<Funcionarios>(new ScanCondition(coluna.ToLower(), ScanOperator.Equal, item.ToLower()));
            
            if (Return == "id") foreach (var result in funcionariosScanResults)
                    resultado = (resultado = result.id);
            if (Return == "nome") foreach (var result in funcionariosScanResults)
                    resultado = (resultado = result.nome);

            if (resultado == "")
            {
                return ("Não Encontrado");

            }

            else
            {
                List<Funcionarios> asList = funcionariosScanResults.ToList();
                asList.ForEach(Console.WriteLine);
                
                Console.WriteLine(asList[0].nome);
                
                return (resultado);
            }

        }

        public static String SearchServicos(DynamoDBContext context, String coluna, String item, String Return)
        {
            String resultado = "";
            IEnumerable<Servicos> servicosScanResults;
            Console.WriteLine();
            servicosScanResults = context.Scan<Servicos>(new ScanCondition(coluna.ToLower(), ScanOperator.Equal, item.ToLower()));

            if (Return == "xml") foreach (var result in servicosScanResults)
                    resultado = (resultado = result.xml);
            if (Return == "id") foreach (var result in servicosScanResults)
                    resultado = (resultado = result.id);
            if (Return == "destinatario") foreach (var result in servicosScanResults)
                    resultado = (resultado = result.cidadeDestinatario);
            if (Return == "nomeDestinatario") foreach (var result in servicosScanResults)
                    resultado = (resultado = result.nomeDestinatario);
            if (Return == "enderecoDestinatario") foreach (var result in servicosScanResults)
                    resultado = (resultado = result.enderecoDestinatario);
            if (Return == "status") foreach (var result in servicosScanResults)
                    resultado = (resultado = result.status);

            if (resultado == "")
            {
                return ("Não Encontrado");

            }

            else
            {
                List<Servicos> asList = servicosScanResults.ToList();
                asList.ForEach(Console.WriteLine);
                
                return (resultado);
            }
        }

        public static String SearchCidades(DynamoDBContext context, String coluna, String item, String Return)
        {
            String resultado = "";
            IEnumerable<Cidades> cidadesScanResults;
            Console.WriteLine();
            cidadesScanResults = context.Scan<Cidades>(new ScanCondition(coluna, ScanOperator.Equal, item.ToLower()));

            if (Return == "cidadeDestinatario") foreach (var result in cidadesScanResults)
                    resultado = (resultado = result.cidadeDestinatario);
            if (Return == "id") foreach (var result in cidadesScanResults)
                    resultado = (resultado = result.id);

            if (resultado == "")
            {
                return ("Não Encontrado");

            }

            else
            {
                List<Cidades> asList = cidadesScanResults.ToList();
                asList.ForEach(Console.WriteLine);

                return (resultado);
            }
        }

        public static List<Funcionarios> SearchDataTabelaFuncionarios(DynamoDBContext context, String id, String nome)
        {
            IEnumerable<Funcionarios> funcionariosScanResults;
            
            if (id != "")
            {
                funcionariosScanResults = context.Scan<Funcionarios>(new ScanCondition("id", ScanOperator.Equal, id.ToLower()));
            }

            else if(nome != "")
            {
                funcionariosScanResults = context.Scan<Funcionarios>(new ScanCondition("nome", ScanOperator.Equal, nome.ToLower()));
            }

            else
            {
                funcionariosScanResults = context.Scan<Funcionarios>();
            }

            List<Funcionarios> asList = funcionariosScanResults.ToList();
            asList.ForEach(Console.WriteLine);
            Console.WriteLine(asList.Count());
            return (asList);
        }

        public static List<Servicos> SearchDataTabelaServicos(DynamoDBContext context, String xml, String id, String destinatario, String enderecoDestinatario, String nomeDestinatario, String status)
        {
            IEnumerable<Servicos> servicosScanResults;

            if (xml != "")
            {
                servicosScanResults = context.Scan<Servicos>(new ScanCondition("xml", ScanOperator.Equal, xml.ToLower()));
            }

            else if (id != "")
            {
                servicosScanResults = context.Scan<Servicos>(new ScanCondition("id", ScanOperator.Equal, id.ToLower()));
            }

            else if (destinatario != "")
            {
                servicosScanResults = context.Scan<Servicos>(new ScanCondition("cidadeDestinatario", ScanOperator.Equal, destinatario.ToLower()));
            }

            else if (enderecoDestinatario != "")
            {
                servicosScanResults = context.Scan<Servicos>(new ScanCondition("enderecoDestinatario", ScanOperator.Equal, destinatario.ToLower()));
            }

            else if (nomeDestinatario != "")
            {
                servicosScanResults = context.Scan<Servicos>(new ScanCondition("nomeDestinatario", ScanOperator.Equal, nomeDestinatario.ToLower()));
            }

            else if (status != "")
            {
                servicosScanResults = context.Scan<Servicos>(new ScanCondition("status", ScanOperator.Equal, status.ToLower()));
            }

            else
            {
                servicosScanResults = context.Scan<Servicos>();
            }

            List<Servicos> asList = servicosScanResults.ToList();
            asList.ForEach(Console.WriteLine);
            Console.WriteLine(asList.Count());
            return (asList);
        }

        public static List<Cidades> SearchDataTabelaCidades(DynamoDBContext context, String cidade, String id)
        {
            IEnumerable<Cidades> cidadesScanResults;

            if (cidade != "")
            {
                cidadesScanResults = context.Scan<Cidades>(new ScanCondition("cidadeDestinatario", ScanOperator.Equal, cidade.ToLower()));
            }

            else if (id != "")
            {
                cidadesScanResults = context.Scan<Cidades>(new ScanCondition("id", ScanOperator.Equal, id.ToLower()));
            }

            else
            {
                cidadesScanResults = context.Scan<Cidades>();
            }

            List<Cidades> asList = cidadesScanResults.ToList();
            asList.ForEach(Console.WriteLine);
            Console.WriteLine(asList.Count());
            return (asList);
        }

        public static String VerificacaoLogin(DynamoDBContext context , String user, String password)
        {
            String senha = "";
            String usuario = "";
            
            IEnumerable<Login> verificaLoginResults;

            try
            {
                verificaLoginResults = context.Scan<Login>(new ScanCondition("user", ScanOperator.Equal, user.ToLower()));
                foreach (var result in verificaLoginResults)
                    senha = (senha = result.password);

                foreach (var result in verificaLoginResults)
                    usuario = (usuario = result.user);

                if (senha == password)
                {
                    return usuario;
                }

                else
                {
                    return "nok";
                }
            }

            catch
            {
                return "nok";
            }
        }

        public static void logoutUser()
        {
            GlobalVariables.usuarioLogin = "";
        }


    }
}

