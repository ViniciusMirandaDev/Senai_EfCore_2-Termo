using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityFCore.Domais;
using EntityFCore.Interfaces;
using EntityFCore.Repositories;
using EntityFCore.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        /// <summary>
        /// Mostra todos os produtos cadastrados
        /// </summary>
        /// <returns>Lista com todos os produtos cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos
                var produtos = _produtoRepository.Listar();

                //Verifico se existe produto cadastrado
                //Caso não exista eu retorno NoContent
                if (produtos.Count == 0)
                    return NoContent();

                //Caso exista retorno Ok e os produtos cadastrados
                return Ok(new
                {
                    totalCount = produtos.Count(),
                    data = produtos
                });
            }
            catch (Exception ex)
            {
                //TODO : Cadastrar mensagem de erro no domínio LogErro
                // Mensagem personalizada
                return BadRequest(new {
                    StatusCode=400,
                    error = "Ocorreu um erro no endpooit Get/produtos, envie um e-mail para email@email.com informando."
                });
            }
        }

        // GET api/produtos/5
        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <returns>Um produto</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busco o produto pelo Id
                Produto produto = _produtoRepository.BuscarPorId(id);

                //Verifico se o produto foi encontrado
                //Caso não exista retorno NotFound
                if (produto == null)
                    return NotFound();

                // Instaciamos a classe moeda
                Moeda dolar = new Moeda();

                //Caso exista retorno Ok e os dados do produto
                return Ok(new { 
                    produto,
                    // Dizemos o valor do produto em Dólar, realizando uma operação entre o valor em real e em dólar
                    valorDolar = produto.Preco / dolar.GetDolarValue()
                });
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        // POST api/produtos
        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="produto">Objeto completo de Produto</param>
        /// <returns>Produto cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                if(produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = urlImagem;
                }

                //Adiciona um novo produto
                _produtoRepository.Adicionar(produto);

                //Retorna Ok caso o produto tenha sido cadastrado
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        // PUT api/produtos/5
        /// <summary>
        /// Altera determinado produto
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <param name="produto">Objeto Produto com as alterações</param>
        /// <returns>Info do produto alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                //Edita o id do produto
                _produtoRepository.Editar(produto);

                //Retorna com ok os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/produtos/5
        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <returns>ID excluidp</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Busca o produto pelo Id
                var produto = _produtoRepository.BuscarPorId(id);

                //Verifica se produto existe
                //Caso não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso exista remove o produto
                _produtoRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

    }
}
