using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Agenda> myAgendas { get; set; }

        public override bool Equals(Object o)
        {
            User user = o as User;
            return user.Name.Equals(this.Name);
        }
    }
}
