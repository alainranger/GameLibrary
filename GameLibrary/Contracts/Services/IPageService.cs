﻿using System.Windows.Controls;

namespace GameLibrary.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
