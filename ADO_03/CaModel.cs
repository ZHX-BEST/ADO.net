using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_03
{
   public class CaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
