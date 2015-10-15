﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CasualMeter.Conductors;
using GalaSoft.MvvmLight.Messaging;
using Gma.UserActivityMonitor;

namespace CasualMeter.Helpers
{
    public class HotkeyHelper
    {
        private static readonly Lazy<HotkeyHelper> Lazy = new Lazy<HotkeyHelper>(() => new HotkeyHelper());

        public static HotkeyHelper Instance
        {
            get { return Lazy.Value; }
        }

        private HotkeyHelper()
        {
        }

        public void Initialize()
        {
            HookManager.KeyDown += HookManagerOnKeyDown;
            HookManager.KeyUp += HookManagerOnKeyUp;
        }

        private void HookManagerOnKeyDown(object sender, KeyEventArgs e)
        {
            if (SettingsHelper.Instance.IsTabVisibilityEnabled && ProcessHelper.Instance.IsTeraActive && e.KeyValue == 9)//check if tab is pressed
                CasualMessenger.Instance.SendWindowVisibilityMessage(true);
        }

        private void HookManagerOnKeyUp(object sender, KeyEventArgs e)
        {
            if (SettingsHelper.Instance.IsTabVisibilityEnabled && e.KeyValue == 9)
                CasualMessenger.Instance.SendWindowVisibilityMessage(false);
        }
    }
}
