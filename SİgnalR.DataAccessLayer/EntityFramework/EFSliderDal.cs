using SignalR.DataAccsessLayer.Abstract;
using SignalR.DataAccsessLayer.Concrete;

using SignalR.EntityLayer.Entities;
using SİgnalR.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccsessLayer.EntityFramework
{
    public class EFSliderDal : GenericRepository<Slider>, ISliderDal
    {
        public EFSliderDal(SignalRContext context) : base(context)
        {
        }
    }
}
