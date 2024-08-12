using KeepIn.Modules.EmployeeManager;

namespace KeepIn.Api.Models;

public record UpdateEmployeeRequest(
    string Id,
    string Name,
    string Email,
    string PhoneNumber,
    string Address,
    Role Role)
{
    public static explicit operator Employee(UpdateEmployeeRequest request)
    {
        return new Employee(id: request.Id)
            .SetName(request.Name)
            .SetEmail(request.Email)
            .SetPhoneNumber(request.PhoneNumber)
            .SetAddress(request.Address)
            .SetRole(request.Role);
    }
};