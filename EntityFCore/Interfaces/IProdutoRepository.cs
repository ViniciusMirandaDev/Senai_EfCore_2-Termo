using EntityFCore.Domais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Interfaces
{
    interface IProdutoRepository
    {
        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>Lista de produtos</returns>
        List<Produto> Listar();
        /// <summary>
        /// Busca produtos por seu nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>Lista de produtos</returns>
        List<Produto> BuscarPorNome(string nome);
        /// <summary>
        /// Busca um produto por seu Id
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <returns>Produto buscado</returns>
        Produto BuscarPorId(Guid id);
        
        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="produto">Objeto Produto a ser adicionado</param>
        void Adicionar(Produto produto);
        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">ID do produto</param>
        void Remover(Guid id);
        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Objeto Produto a ser editado</param>
        void Editar(Produto produto);

    }
}
