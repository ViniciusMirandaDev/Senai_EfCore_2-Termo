using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Domais
{
    public abstract class BaseDomain
    {
        [Key]
        //Definir o set como private, para  que ele não seja alterado em outros lugares(Importante!!)
        public Guid Id { get; private set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public void setId(Guid id)
        {
            id = Id;
        }
    }
}
