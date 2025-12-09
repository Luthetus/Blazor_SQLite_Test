using BlazorApp1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// I have what I wanted, I'll put this build error so the website doesn't update
// with this broken code.
//
// It seems I can do what I did in BlazorApp2 in BlazorApp1...
// I was having dotnet-ef issues
// but looked up the package manager console equivalent and then things worked.
// By then I'd already swapped to ServerSide thinking that was the issue.
s

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDbContextFactory<EmployeeDataContext>(options => options.UseSqlite("Data Source=Employees.db"));

await builder.Build().RunAsync();
