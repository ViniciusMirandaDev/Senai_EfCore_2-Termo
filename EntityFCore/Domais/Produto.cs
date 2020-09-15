using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Domais
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        //Usada para receber o arquivo
        [NotMapped]
        [JsonIgnore]
        public IFormFile Imagem { get; set; }
        //Url da imagem salva localmente
        public string UrlImagem { get; set; }
        public List<PedidoItem> PedidoItens { get; set; }
    }
}
