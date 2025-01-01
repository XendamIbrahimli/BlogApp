using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Exceptions.NotFoundExceptionWithType
{
    public class NotFoundException<T> : NotFoundException 
    {
        public NotFoundException() : base(typeof(T).Name + "Not found")
        {

        }
    }
}
