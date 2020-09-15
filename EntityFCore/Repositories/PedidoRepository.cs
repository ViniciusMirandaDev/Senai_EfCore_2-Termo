using EntityFCore.Contexts;
using EntityFCore.Domais;
using EntityFCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {

                //Criação do objeto do tipo pedido passando os valores
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now
                    //Outra forma de instaciar a lista, que está como construtor em pedido.cs
                    //PedidosItens = new List<PedidoItem>()
                };
                
                //Percorre a lista de pedidosItens e adiciona a lista de pedidosItens
                foreach (var item in pedidosItens)
                {
                    //Adiciona um pedidoitem a lista
                    pedido.PedidosItens.Add(new PedidoItem 
                    { 
                        IdPedido = pedido.Id, //Id do Objeto Criado acima
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }

                //Adiciono o pedido ao contexto
                _ctx.Pedidos.Add(pedido);
                //Salvo as alterações no banco de dados
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }   
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos
                    .Include(c => c.PedidosItens)
                    .ThenInclude(c => c.Produto)
                    .FirstOrDefault(p => p.Id == id);//Fazemos um Inner Join 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
