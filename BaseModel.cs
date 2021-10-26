using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_APP
{
    public static class BaseModel
    {
        private static WPF_DB_Entities Context;
        public static WPF_DB_Entities GetContext()
        {
            if (Context != null)
            {
                return Context;
            }
            else
            {
                Context = new WPF_DB_Entities();
                return Context;
            }
        }
    }

    enum Roles
    {
        ADMINISTRATOR = 1,
        USER
    }
}
