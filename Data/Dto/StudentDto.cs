using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class StudentDto
    {
        // DTO para mascarar as entidades para não retorná-las diretamente
        public int Key { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;

    }
}
