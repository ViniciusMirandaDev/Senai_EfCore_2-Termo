using EntityFCore.Domais;
using System;
using System.Collections.Generic;

namespace EntityFCore.Interfaces
{
    interface IPedidoRepository
    {
        List<Pedido> Listar();
        Pedido BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">Itens do pedido</param>
        /// <returns>Pedido</returns>
        Pedido Adicionar(List<PedidoItem> pedidosItens);
        
    }
}
