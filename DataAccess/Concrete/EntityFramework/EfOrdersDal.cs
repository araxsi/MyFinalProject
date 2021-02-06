using Core.DataAccess.EntityFramework;
using DataAccess.Abstrack;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfOrdersDal: EfEntityRepostoryBase<Orders, NortwindContext>,IOrdersDal
    {
    }
}
