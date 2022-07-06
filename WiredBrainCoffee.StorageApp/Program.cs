using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;


var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;

AddEmployees(employeeRepository);
AddManagers(employeeRepository);
GetEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);

void EmployeeRepository_ItemAdded(object? sender, Employee e)
{
    
    Console.WriteLine($"Employee added => {e.FirstName}");
}

void AddManagers(IWriteRepository<Manager> managerRepository)
{
    var saraManager = new Manager { FirstName = "Sara" };
    var saraManagerCopy = saraManager.Copy();
    managerRepository.Add(saraManager);

    if (saraManagerCopy != null)
    {
        saraManagerCopy.FirstName += "_Copy";
        managerRepository.Add(saraManagerCopy);
    }
    managerRepository.Add(new Manager { FirstName = "Big Dawg" });
    managerRepository.Save();
}

void WriteAllToConsole(IReadRepository<IEntity> employeeRepository)
{
    var items = employeeRepository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

void GetEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine($"Employee with Id of 2: {employee?.FirstName}");
}

var organizationRepository = new ListRepository<Organization>();
AddOrganizations(organizationRepository);
WriteAllToConsole(organizationRepository);

Console.ReadLine();

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
        new Employee { FirstName = "Larry" },
        new Employee { FirstName = "Geeg" },
        new Employee { FirstName = "Marissa" },
        new Employee { FirstName = "Vance" }
    };
    employeeRepository.AddBatch(employees);
}

static void AddOrganizations(IRepository<Organization> organizationRepository)
{
    var organizations = new[]
    {
        new Organization { Name = "Pluralsight"},
        new Organization { Name = "Globomantics"}
    };

    organizationRepository.AddBatch(organizations);
}
