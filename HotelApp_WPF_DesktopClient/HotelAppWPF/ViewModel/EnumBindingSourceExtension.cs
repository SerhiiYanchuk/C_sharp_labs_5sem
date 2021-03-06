﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace HotelAppWPF
{
    public class EnumBindingSourceExtension: MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
                throw new Exception("EnumType must not be null and of type Enum");
            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvide)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
