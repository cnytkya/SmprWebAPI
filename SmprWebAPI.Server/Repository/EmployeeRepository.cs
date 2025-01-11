using Microsoft.EntityFrameworkCore;
using SmprWebAPI.Server.Data;
using SmprWebAPI.Server.Models;

namespace SmprWebAPI.Server.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _appDbcontext;

        public EmployeeRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _appDbcontext.Employees.ToListAsync();
        }

        public async Task SaveEmp(Employee employee)
        {
            await _appDbcontext.Employees.AddAsync(employee);
            await _appDbcontext.SaveChangesAsync();
        }

        public async Task DeleteEmp(int id)
        {
            var emp = await _appDbcontext.Employees.FindAsync(id);
            if (emp != null)
            {
                _appDbcontext.Employees.Remove(emp);
                await _appDbcontext.SaveChangesAsync();
            }
        }

        public async Task UpdateEmp(Employee employee)
        {
            var existingEmp = await _appDbcontext.Employees.FindAsync(employee.Id);
            if (existingEmp != null)
            {
                existingEmp.Name = employee.Name;
                existingEmp.Email = employee.Email;
                existingEmp.Mobile = employee.Mobile;
                existingEmp.Age = employee.Age;
                existingEmp.Salary = employee.Salary;
                existingEmp.Status = employee.Status;
                _appDbcontext.Employees.Update(employee);
                await _appDbcontext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmpById(int id)
        {
            return await _appDbcontext.Employees.FindAsync(id);
        }
    }
}