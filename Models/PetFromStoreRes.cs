using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_PetStore.Models
{
    public class PetFromStoreRes
    {


        
        public long id { get; set; }
        public PetCategory category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public PetTag[] tags { get; set; }
        public string status { get; set; }
        

    }
}
