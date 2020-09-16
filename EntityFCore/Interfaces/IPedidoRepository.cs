using EntityFCore.Domais;
using System;
using System.Collections.Generic;

namespace EntityFCore.Interfaces
{
    interface IPedidoRepository
    {
        /// <summary>
        /// Lista todos os pedidos
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        List<Pedido> Listar();
        /// <summary>
        /// Busca um pedido por Id
        /// </summary>
        /// <param name="id">ID do pedido</param>
        /// <returns>Pedido buscado</returns>
        Pedido BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">Lista de itens do pedido</param>
        /// <returns>Pedido</returns>
        Pedido Adicionar(List<PedidoItem> pedidosItens);
        
    }
}
