﻿using Instrument.Gui.Controls.FloatDock.Base.Interfaces;
using Instrument.Gui.Controls.FloatDock.Layout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Instrument.Gui.Controls.FloatDock.Base
{
    public abstract class LayoutConfig : LayoutObject, ILayoutAttachable
    {
        public abstract Layout.Type Type { get; }
    }
}