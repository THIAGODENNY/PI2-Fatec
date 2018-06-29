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

using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ConexaoAWS
{
    [DynamoDBTable("funcionarios")]
    public class Funcionarios
    {
        [DynamoDBHashKey]
        public string id { get; set; }

        [DynamoDBRangeKey("nome")]
        public string nome { get; set; }

    }

    [DynamoDBTable("servicos")]
    public class Servicos
    {
        [DynamoDBHashKey]
        public string xml { get; set; }

        [DynamoDBProperty("id")]
        public string id { get; set; }

        [DynamoDBProperty("nomeDestinatario")]
        public string nomeDestinatario { get; set; }

        [DynamoDBProperty("enderecoDestinatario")]
        public string enderecoDestinatario { get; set; }

        [DynamoDBProperty("cidadeDestinatario")]
        public string cidadeDestinatario { get; set; }

        [DynamoDBProperty("status")]
        public string status { get; set; }
        
    }

    [DynamoDBTable("cidades")]
    public class Cidades
    {
        [DynamoDBHashKey]
        public string cidadeDestinatario { get; set; }

        [DynamoDBProperty("id")]
        public string id { get; set; }

    }

    [DynamoDBTable("login")]
    public class Login
    {
        [DynamoDBHashKey]
        public string user { get; set; }

        [DynamoDBProperty("id")]
        public string password { get; set; }
    }
}
