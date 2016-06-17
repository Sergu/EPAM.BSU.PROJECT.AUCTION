using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces.Entities
{
    public class UserEntity : IBllEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int Money { get; set; }
        public string Email { get; set; }
    }
}
