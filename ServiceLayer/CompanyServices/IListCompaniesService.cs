﻿// Copyright (c) 2019 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Html;

namespace ServiceLayer.CompanyServices
{
    public interface IListCompaniesService
    {
        List<HtmlString> BuildViewOfHierarchy();
    }
}