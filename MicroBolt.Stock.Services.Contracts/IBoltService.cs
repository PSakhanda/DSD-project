using MicroBolt.Stock.Models;
using System;

namespace MicroBolt.Stock.Services.Contracts
{
    public interface IBoltService
    {
        Bolt Get(int id);
        int Create(Bolt model);
        void Update(Bolt model);
        void Delete(int id);
    }
}
