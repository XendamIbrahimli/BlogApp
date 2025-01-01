using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Exceptions.GenericExistException
{
    public class ExistException<T> : ExistException
    {
        public ExistException() : base(typeof(T).Name+"is exist")
        {
        }
    }
}
