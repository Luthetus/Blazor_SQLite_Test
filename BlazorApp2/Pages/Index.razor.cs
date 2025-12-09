using BlazorApp2.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Pages;

public partial class Index
{
    private EmployeeDataContext? _context;
    public Employee? NewEmployee { get; set; }

    public bool ShowCreate { get; set; }
    public List<Employee>? OurEmployees { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ShowCreate = false;
        await ShowEmployees();
    }

    public void ShowCreateForm()
    {
        NewEmployee = new Employee();
        ShowCreate = true;
    }

    public async Task ShowEmployees()
    {
        _context ??= await EmployeeDataContextFactory.CreateDbContextAsync();

        if (_context is not null)
        {
            OurEmployees = await _context.Employees.ToListAsync();
        }

        //if (_context is not null) await _context.DisposeAsync();
    }

    public async Task CreateNewEmployee()
    {
        _context ??= await EmployeeDataContextFactory.CreateDbContextAsync();

        if (NewEmployee is not null)
        {
            _context?.Employees.Add(NewEmployee);
            _context?.SaveChangesAsync();
        }
        ShowCreate = false;
    }
}
