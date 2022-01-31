using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLicenceDal : EfEntityRepositoryBase<Licence, HukukContext>, ILicenceDal
    {
        public List<Licence> LicenceWithCity()
        {
            using (var context = new HukukContext())
            {
                return context.Licences.Include(l => l.City).ToList();

            }
        }
    }
}
