using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Modals.ModalsDTO
{
    public class SubscribePut
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public int NumOfBorrows { get; set; } = 0;
        public int NumOfCurrentBorrowing { get; set; } = 0;

    }
}
