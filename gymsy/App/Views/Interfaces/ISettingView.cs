﻿using gymsy.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymsy.App.Views.Interfaces
{
    internal interface ISettingView
    {

        Person person { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // Methods
        void Show();
        void Refresh();

    }
}
