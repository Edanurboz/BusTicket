using Business.DTO;

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBusService
    {
        string Create(CreateBusDTO bus);
        void Update(UpdateBusDTO bus);
        void Delete(DeleteBusDTO bus);
        List<Bus> GetAll();
        object GetBusById(int id);
    }
}
