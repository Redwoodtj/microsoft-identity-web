﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Identity.Web
{
    /// <summary>
    /// Extension for IServiceCollection for startup initialization of Web APIs.
    /// </summary>
    public static partial class MicrosoftIdentityWebApiServiceCollectionExtensions
    {
        /// <summary>
        /// Protects the web API with Microsoft identity platform (formerly Azure AD v2.0)
        /// This method expects the configuration file will have a section, named "AzureAd" as default, with the necessary settings to initialize authentication options.
        /// </summary>
        /// <param name="services">Service collection to which to add authentication.</param>
        /// <param name="configuration">The Configuration object.</param>
        /// <param name="configSectionName">The configuration section with the necessary settings to initialize authentication options.</param>
        /// <param name="jwtBearerScheme">The JwtBearer scheme name to be used. By default it uses "Bearer".</param>
        /// <param name="subscribeToJwtBearerMiddlewareDiagnosticsEvents">
        /// Set to true if you want to debug, or just understand the JwtBearer events.</param>
        /// <returns>The authentication builder to chain extension methods.</returns>
        [Obsolete("Rather use AddMicrosoftIdentityWebApiAuthentication(). See https://aka.ms/ms-id-web/0.3.0-preview")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MicrosoftIdentityWebApiAuthenticationBuilderWithConfiguration AddMicrosoftWebApiAuthentication(
            this IServiceCollection services,
            IConfiguration configuration,
            string configSectionName = Constants.AzureAd,
            string jwtBearerScheme = JwtBearerDefaults.AuthenticationScheme,
            bool subscribeToJwtBearerMiddlewareDiagnosticsEvents = false)
        {
            AuthenticationBuilder builder = services.AddAuthentication(jwtBearerScheme);
            return builder.AddMicrosoftIdentityWebApi(
                configuration,
                configSectionName,
                jwtBearerScheme,
                subscribeToJwtBearerMiddlewareDiagnosticsEvents);
        }
    }
}