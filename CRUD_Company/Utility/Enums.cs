using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Company.Utility
{
    public class Enums
    { 
        enum CrudType: int
        {
            All = 0,
            Create = 1,
            Update = 2,
            View = 4,
            Delete = 8
        }
    }
}
