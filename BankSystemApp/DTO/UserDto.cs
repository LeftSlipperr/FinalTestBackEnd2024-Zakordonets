using BuildingSystem.Domain.Models;

namespace BankSystemApp.DTO;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Building> Buildings { get; set; }
}