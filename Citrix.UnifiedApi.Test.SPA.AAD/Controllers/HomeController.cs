/*
* Copyright © 2025. Cloud Software Group, Inc.
* This file is subject to the license terms contained
* in the license file that is distributed with this file.
*/

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Citrix.UnifiedApi.Test.SPA.AAD.Models;
using Microsoft.Extensions.Options;

namespace Citrix.UnifiedApi.Test.SPA.AAD.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationConfig _applicationConfig;
    
    public HomeController(ILogger<HomeController> logger, IOptions<ApplicationConfig> applicationConfig)
    {
        _logger = logger;
        _applicationConfig = applicationConfig.Value;
    }

    public IActionResult Index()
    {
        return View(_applicationConfig);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}