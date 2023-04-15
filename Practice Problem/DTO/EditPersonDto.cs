using Practice_Problem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problem.DTO
{
    class EditPersonDto : PersonData
    {
        public Guid Id { get; set; }
    }
}
