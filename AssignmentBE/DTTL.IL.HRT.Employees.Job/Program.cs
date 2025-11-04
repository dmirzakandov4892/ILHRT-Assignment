
// Code snippets are only available for the latest version. Current version is 5.x
using Azure.Identity;
using DTTL.IL.HRT.Employees.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using static System.Formats.Asn1.AsnWriter;

var _host = Host.CreateDefaultBuilder()
                 .ConfigureServices((context, services) =>
                 {
                     services.AddHttpClient<MSGraphToken>(client =>
                     {
                         client.BaseAddress = new Uri("https://localhost:7261/");
                         client.DefaultRequestHeaders.Add("Accept", "application/json");
                     });
                 })
                    .UseConsoleLifetime()
                    .Build();

var graphClientToken = _host.Services.GetRequiredService<MSGraphToken>();
var loggerText = new LoggerConfiguration()
                                .WriteTo.Console()
                               .WriteTo.File(Utils.getTxtFileName(0), fileSizeLimitBytes: null)
                               .MinimumLevel.Debug()
                               .CreateLogger();

UsersFileHandler jrw = new($"./{Utils.getJsonUsersFiles()}", $"./{Utils.getJsonFileName(0)}");

List<DTTL.IL.HRT.Employees.Shared.User> users = jrw.ReadUsersDaily();

if (users == null || users.Count == 0)
{
    users = jrw.ReadUsers();

    if (users == null || users.Count == 0)
    {
        var allHRTusersGraph = await graphClientToken.GetAllHRTUsers();
        if (allHRTusersGraph != null)
            foreach (var item in allHRTusersGraph)
            {
                users.Add(new DTTL.IL.HRT.Employees.Shared.User(item));
            }
        jrw.WriteUsers(users);
    }
}



//if (users != null)
//    foreach (var u in users)
//    {
//        if (u != null)
//        {
//            foreach (var s in u.Skills)
//            {
//                u.Skills[s.Key]++;
//            }
//            loggerText.Information(u.ToString());

//        }
//    }
//jrw.WriteUsersDaily(users);


// Determine if this is a second run or more (daily file already exists)
var dailyUsers = jrw.ReadUsersDaily();
bool isSecondRunOrMore = dailyUsers != null && dailyUsers.Count > 0;

// If daily exists, use it as current list; otherwise, use the main file
if (isSecondRunOrMore)
    users = dailyUsers;

// --- Logic update ---
if (users != null)
{
    if (isSecondRunOrMore)
    {
        // Second run or more: set all skills to 2
        foreach (var u in users)
        {
            if (u?.Skills == null) continue;
            var keys = u.Skills.Keys.ToList();
            foreach (var key in keys)
                u.Skills[key] = 2;

            loggerText.Information($"[Second Run] Updated skills for {u.UserName}");
        }
    }
    else
    {
        // First run: just log users normally
        foreach (var u in users)
            loggerText.Information($"[First Run] {u.UserName}");
    }
}

// Write daily file after updates
jrw.WriteUsersDaily(users);







