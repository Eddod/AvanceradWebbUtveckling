using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _appDbContext.Customers.ToList();
        }


        public void Add(Customer customer)
        {
            var customertoAdd = _appDbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();


        }

        public Customer GetSingle(int id)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Customer customer)
        {
            _appDbContext.Entry(customer).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            var customerToDelete = _appDbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToDelete != null)
            {

                _appDbContext.Remove(customerToDelete);
            }


        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

    }
}
