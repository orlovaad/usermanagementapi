using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public interface IUserService
    {
        public bool CheckAge(DateTime dateOfBirth);
        public decimal GetDiscount(AccountType accountType);
        public string GetFeatures(AccountType accountType);
    }
}
