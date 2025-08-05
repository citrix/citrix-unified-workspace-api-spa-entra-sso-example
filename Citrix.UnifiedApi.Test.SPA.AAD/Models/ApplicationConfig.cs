/*
* Copyright © 2025. Cloud Software Group, Inc.
* This file is subject to the license terms contained
* in the license file that is distributed with this file.
*/

namespace Citrix.UnifiedApi.Test.SPA.AAD.Models;

public class ApplicationConfig
{
    /// <summary>
    /// The application ID for the Workspace OAuth client you're using.
    /// </summary>
    /// <remarks>Should be in standard UUID format.</remarks>
    public string ApplicationId { get; set; }
    
    /// <summary>
    /// The domain for the customer you wish to use.
    /// </summary>
    /// <remarks>Should be in format {customer}.cloud.com</remarks>
    public string CustomerDomain { get; set; }
    
    /// <summary>
    /// The base URL to use to talk to the Token Management Service.
    /// </summary>
    /// <remarks>Should be without a trailing slash.</remarks>
    public string TokenManagementBaseUrl { get; set; }
}