using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int money { get; set; }
        public string email { get; set; }
    }
}
