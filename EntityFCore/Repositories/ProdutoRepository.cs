using EntityFCore.Contexts;
using EntityFCore.Domais;
using EntityFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EntityFCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
           _ctx = new PedidoContext();
        }

        #region Leitura
        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de Produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Busca um produtor pelo ID
        /// </summary>
        /// <param name="id">Id do Produto</param>
        /// <returns>Produto buscado</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                // return _ctx.Produtos.FirstOrDefault(x => x.Id == id);
                return _ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca o produto pelo nome
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        /// <returns>Lista de Produtos</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(x => x.Nome.Contains(nome)).ToList(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação
        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Produto a ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Busca o produto pelo seu Id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se o produto existe
                //Caso não exista ele gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista altera suas propriedades
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Atualiza o produto do dbSet
                _ctx.Produtos.Update(produtoTemp);
                //Salva as alterações do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //Mostra a mensagem de erro
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adiciona o objeto produto  ao dbset do contexto
                _ctx.Produtos.Add(produto);
                //Salva as alterações do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //Mostra a mensagem de erro
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remoce um produto
        /// </summary>
        /// <param name="id">Id do Produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Busca o produto pelo seu Id
                Produto produtoTemp = BuscarPorId(id);

                //Verifica se o produto existe

                //Remove os produtos do dbSet
                _ctx.Produtos.Remove(produtoTemp);
                //Salva as alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //Mostra a mensagem de erro
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
