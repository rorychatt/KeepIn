using KeepIn.Modules.EmployeeManager;

namespace KeepIn.Api.Models;

public record AddEmployeeRequest(string Name, string Email, string PhoneNumber, string Address, Role Role)
{
    public static explicit operator Employee(AddEmployeeRequest request)
    {
        return new Employee()
            .SetName(request.Name)
            .SetEmail(request.Email)
            .SetPhoneNumber(request.PhoneNumber)
            .SetAddress(request.Address)
            .SetRole(request.Role);
    }
};